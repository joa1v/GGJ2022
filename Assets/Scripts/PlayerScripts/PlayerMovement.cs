using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Dice _dice;
    [SerializeField] private TilesManager _tiles;
    [SerializeField] private TurnManager _turnManager;
    private Player _player;
    //private bool canMove = true;
    [SerializeField] private Path currentPath;
    private IntersectionTile intersection;

    private int _pathTileId = 0;
    private int _movementsLeft = 0;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _player.turn)
        {
            Move(_dice.Roll());
        }

        if (intersection)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (intersection.leftPath)
                {
                    currentPath = intersection.leftPath;
                    Internal_Move();
                    intersection.HideArrows();
                }

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (intersection.rightPath)
                {
                    currentPath = intersection.rightPath;
                    Internal_Move();
                    intersection.HideArrows();
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (intersection.fwPath)
                {
                    currentPath = intersection.fwPath;
                    Internal_Move();
                    intersection.HideArrows();
                }
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
        intersection = currentPath.tiles[_pathTileId].GetComponent<IntersectionTile>();

        if (intersection)
            ChangePath(intersection);


        if (_movementsLeft > 0)
        {
            Internal_Move();
            _movementsLeft--;
        }
    }

    private void Internal_Move()
    {
        Vector3 p = currentPath.tiles[_pathTileId].transform.position;
        transform.position = new Vector3(p.x, transform.position.y, p.z);

        if (_pathTileId < currentPath.tiles.Length - 1)
            _pathTileId++;

        //CheckMove();
    }

    //IEnumerator Wait(float timeToWait)
    //{
    //    canMove = false;
    //    yield return new WaitForSeconds(timeToWait);
    //    canMove = true;
    //}

    private void ChangePath(IntersectionTile intersection)
    {
        intersection.ShowArrows();
    }
}
