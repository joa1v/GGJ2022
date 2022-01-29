using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionTile : Tile
{
    public Path leftPath;
    public Path rightPath;

    [SerializeField] private GameObject _arrows;

    public void ShowArrows()
    {
        _arrows.SetActive(true);
    }


    public void HideArrows()
    {
        _arrows.SetActive(false);
    }

}
