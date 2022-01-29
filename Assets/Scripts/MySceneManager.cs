using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static void GoToScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
