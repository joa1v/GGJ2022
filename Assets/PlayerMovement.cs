using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Dice _dice;
    [SerializeField] private TilesManager _tiles;
    [SerializeField] private TurnManager _turnManager;
    private Player player;
    private bool canMove = true;
    [SerializeField] private Path currentPath;
    private IntersectionTile intersection;

    private int _pathTileId = 0;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.turn)
        {
            Move(_dice.Roll());
        }

        if (intersection)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (intersection.leftPath)
                {
                    _pathTileId = 0;
                    currentPath = intersection.leftPath;
                    intersection.HideArrows();
                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (intersection.rightPath)
                {
                    _pathTileId = 0;
                    currentPath = intersection.rightPath;
                    intersection.HideArrows();
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                if (intersection.fwPath)
                {
                    _pathTileId = 0;
                    currentPath = intersection.fwPath;
                    intersection.HideArrows();
                }
            }
        }
    }

    public void Move(int places)
    {
        while (places > 0)
        {
            intersection = currentPath.tiles[_pathTileId].GetComponent<IntersectionTile>();

            if (canMove)
            {
                Vector3 p = currentPath.tiles[_pathTileId].transform.position;
                transform.position = new Vector3(p.x, transform.position.y, p.z);

                if (_pathTileId < currentPath.tiles.Length-1)
                    _pathTileId++;

                if (intersection)
                    ChangePath(intersection);
            }

            places--;
        }
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
