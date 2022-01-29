using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Dice _dice;
    [SerializeField] private TilesManager _tiles;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Path _currentPath;
    private IntersectionTile _intersection;
    private Player _player;
    private MinigameTile _miniGame;
    private int _pathTileId = 0;
    private int _movementsLeft = 0;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (TurnManager.canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _player.turn)
            {
                Move(_dice.Roll());
            }
        }

        if (_intersection)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_intersection.leftPath)
                {
                    _currentPath = _intersection.leftPath;

                    _pathTileId = 0;
                    CheckMove();
                }

                if (_intersection)
                    _intersection.HideArrows();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_intersection.rightPath)
                {
                    _currentPath = _intersection.rightPath;

                    _pathTileId = 0;
                    CheckMove();
                }

                if (_intersection)
                    _intersection.HideArrows();
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
                if (_tiles.TreatOrTrick())
                    _tiles.Treat();
                else
                {
                    _tiles.minigameScene = _miniGame._minigameSceneId;
                    _tiles.Trick();
                }
            }

            _turnManager.ChangeTurns();
            TurnManager.canMove = true;
        }
        if (_movementsLeft > 0)
        {
            TurnManager.canMove = false;
            Internal_Move();
            _movementsLeft--;
        }

        _intersection = _currentPath.tiles[_pathTileId].GetComponent<IntersectionTile>();

        if (_intersection)
            ChangePath(_intersection);
    }

    private void Internal_Move()
    {
        if (_pathTileId < _currentPath.tiles.Length - 1)
            _pathTileId++;

        Vector3 p = _currentPath.tiles[_pathTileId].transform.position;
        transform.position = new Vector3(p.x, transform.position.y, p.z);

        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        CheckMove();
    }

    private void ChangePath(IntersectionTile intersection)
    {
        intersection.ShowArrows();
    }
}
