using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int savedPlayerPos;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;


    public static bool isPaused;

    [SerializeField] private AudioClip _winSFX;

    [SerializeField] private Image playerImg;
    [SerializeField] Sprite[] _playerImgs;


    public void Win(int playerID)
    {
        playerImg.sprite = _playerImgs[playerID];
        winPanel.SetActive(true);
        AudioManager.Instance.PlayAudio(_winSFX);
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

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
    }
}
