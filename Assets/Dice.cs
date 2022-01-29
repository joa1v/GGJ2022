using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;

    public int diceNum;
    public int Roll()
    {
        int num = Random.Range(_min, _max);

        diceNum = num;
        return num;
    }
}
