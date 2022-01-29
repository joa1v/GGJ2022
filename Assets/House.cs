using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float threatPercent;

    public bool GetLucky()
    {
        float num = Random.Range(0f, 100f);

        if (num < threatPercent)
            return true;
        else
            return false;
    }

}
