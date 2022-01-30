using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int savedPlayerPos;
    [SerializeField] private TextMeshProUGUI winTxt;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;

    public static bool isPaused;

    public void Win(int playerID)
    {
        winTxt.text = "Player: " + playerID + " wins!!";
        winPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
        }

        if (isPaused)
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(isPaused);
    }
}
