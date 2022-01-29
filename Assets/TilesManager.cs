using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _minigames;
    public int[] tilesHouse;

    public bool CheckTile(int tile)
    {
        if (tilesHouse.Contains(tile))
        {
            Minigame();
            return true;
        }
        else
            return false;
    }

    public void Minigame()
    {
        int n = Random.Range(0, _minigames.Length);

        _minigames[n].SetActive(true);
    }

}
