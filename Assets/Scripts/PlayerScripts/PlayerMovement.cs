using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Dice _dice;
    [SerializeField] private TilesManager _tiles;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Path _currentPath;
    [SerializeField] private AudioClip _stepSound;

    public int currentPathId;
    public int _pathTileId;


    private IntersectionTile _intersection;
    private MinigameTile _miniGame;

    private Player _player;
    private int _movementsLeft;

    static int savedPlayerPos;

    private void Start()
    {
        _player = GetComponent<Player>();

        if (savedPlayerPos == 2)
        {
            if (_player.id == 0)
            {
                currentPathId = PlayerPrefs.GetInt("PathID1");
                _currentPath = _tiles.paths[currentPathId];
                _pathTileId = PlayerPrefs.GetInt("PathTileId1");
            }
            else
            {
                currentPathId = PlayerPrefs.GetInt("PathID2");
                _currentPath = _tiles.paths[currentPathId];
                _pathTileId = PlayerPrefs.GetInt("PathTileId2");
            }
        }

        if (savedPlayerPos < 2)
            savedPlayerPos++;
    }

    private void Update()
    {
        if (_intersection && _movementsLeft > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_intersection.leftPath)
                {
                    TurnManager.canMove = true;
                    _currentPath = _intersection.leftPath;
                    _pathTileId = 0;
                    _intersection.HideArrows();

                    CheckMove();
                }

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_intersection.rightPath)
                {
                    TurnManager.canMove = true;
                    _currentPath = _intersection.rightPath;
                    _pathTileId = 0;

                    _intersection.HideArrows();
                    CheckMove();
                }
            }
        }

        if (TurnManager.canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _player.turn && !GameManager.isPaused)
            {
                Move(_dice.Roll());
            }
        }
    }

    public void Move(int places)
    {
        _movementsLeft += places;
        CheckMove();
    }

    private void CheckMove()
    {
        if (_movementsLeft == 0)
        {
            _miniGame = _currentPath.tiles[_pathTileId].GetComponent<MinigameTile>();

            if (_miniGame)
            {
                _turnManager.CheckTurns();
                bool treatOrTrick = _tiles.TreatOrTrick();

                if (!treatOrTrick)
                {
                    _tiles.Treat(_player.id);
                    _turnManager.ChangeTurns();
                }
                else
                {
                    _tiles.minigameScene = _miniGame._minigameSceneId;
                    _tiles.Trick(_player.id);
                }
            }
            else
            {
                _turnManager.ChangeTurns();
            }

            TurnManager.canMove = true;
        }

        if (_movementsLeft > 0 && TurnManager.canMove)
        {
            Internal_Move();
            _movementsLeft--;
        }

        _intersection = _currentPath.tiles[_pathTileId].GetComponent<IntersectionTile>();

        if (_intersection && _movementsLeft > 0)
            ChangePath(_intersection);
    }

    private void Internal_Move()
    {
        if (_pathTileId < _currentPath.tiles.Length - 1)
            _pathTileId++;

        Vector3 p = _currentPath.tiles[_pathTileId].transform.position;
        transform.position = new Vector3(p.x, transform.position.y, p.z);
        AudioManager.Instance.PlayOneShotAudio(_stepSound);
        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        if (!_intersection)
            TurnManager.canMove = true;

        CheckMove();
    }

    private void ChangePath(IntersectionTile intersection)
    {
        intersection.ShowArrows();
        TurnManager.canMove = false;
    }

    public void SavePositions()
    {
        currentPathId = _tiles.GetPathId(_currentPath);

        if (_player.id == 0)
        {
            PlayerPrefs.SetInt("PathID1", currentPathId);
            PlayerPrefs.SetInt("PathTileId1", _pathTileId);
        }
        else
        {
            PlayerPrefs.SetInt("PathID2", currentPathId);
            PlayerPrefs.SetInt("PathTileId2", _pathTileId);
        }
    }
}
