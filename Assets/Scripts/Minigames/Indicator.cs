using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool inArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inArea = false;

    }
}
