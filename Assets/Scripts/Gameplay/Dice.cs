using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;

    [SerializeField] private Image diceImg;

    [SerializeField] private Sprite[] diceFaces;

    public int diceNum;

    public int Roll()
    {
        int num = Random.Range(_min, _max+1);

        diceNum = num;
        diceImg.sprite = diceFaces[num-1];
        return num;
    }
}
