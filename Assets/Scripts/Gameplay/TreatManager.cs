using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatManager : MonoBehaviour
{
    public static void AddTreat(int playerID, int amount)
    {
        int treats = PlayerPrefs.GetInt("Player" + playerID.ToString() + "Treat");
        PlayerPrefs.SetInt("Player" + playerID.ToString() + "Treat", treats + amount);
    }

}
