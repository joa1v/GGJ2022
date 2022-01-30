using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool turn;

    public int id;

    private void Start()
    {
        if (GameManager.savedPlayerPos == 2)
        {
            if (id == 0)
            {
                if (PlayerPrefs.HasKey("Player1x"))
                {
                    float x = PlayerPrefs.GetFloat("Player1x");
                    float y = PlayerPrefs.GetFloat("Player1y");
                    float z = PlayerPrefs.GetFloat("Player1z");

                    Vector3 pos = new Vector3(x, y, z);
                    transform.position = pos;
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("Player2x"))
                {
                    float x = PlayerPrefs.GetFloat("Player2x");
                    float y = PlayerPrefs.GetFloat("Player2y");
                    float z = PlayerPrefs.GetFloat("Player2z");

                    Vector3 pos = new Vector3(x, y, z);
                    transform.position = pos;
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("Player0Treat", 0);
            PlayerPrefs.SetInt("Player1Treat", 0);

        }

        if (GameManager.savedPlayerPos < 2)
            GameManager.savedPlayerPos++;

    }

    private void OnDisable()
    {
        if (id == 0)
        {
            PlayerPrefs.SetFloat("Player1x", transform.position.x);
            PlayerPrefs.SetFloat("Player1y", transform.position.y);
            PlayerPrefs.SetFloat("Player1z", transform.position.z);
        }
        else
        {
            PlayerPrefs.SetFloat("Player2x", transform.position.x);
            PlayerPrefs.SetFloat("Player2y", transform.position.y);
            PlayerPrefs.SetFloat("Player2z", transform.position.z);
        }
    }

    private void OnApplicationQuit()
    {
        GameManager.savedPlayerPos = 0;

    }

}
