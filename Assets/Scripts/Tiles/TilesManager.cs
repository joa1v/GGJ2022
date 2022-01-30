using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TilesManager : MonoBehaviour
{
    [SerializeField] private float _threatPercent;
    [SerializeField] private float _loadTime;
    [SerializeField] private GameObject _treatPanel;
    [SerializeField] private GameObject _trickPanel;

    [HideInInspector] public int minigameScene;

    public Path[] paths;


    public bool TreatOrTrick()
    {
        float num = Random.Range(0f, 100f);

        if (num < _threatPercent)
            return true;
        else
            return false;
    }

    public void Treat(int id)
    {
        TreatManager.AddTreat(id, 1);
        _trickPanel.SetActive(true);
    }

    public void Trick(int id)
    {
        Debug.Log("load trick");
        _trickPanel.SetActive(true);
        PlayerPrefs.SetInt("CurrentMinigamePlayerId", id);
        StartCoroutine(LoadTrick(_loadTime));
    }

    IEnumerator LoadTrick(float loadTime)
    {
        yield return new WaitForSeconds(loadTime);
        MySceneManager.GoToScene(minigameScene);
    }

    public int GetPathId(Path path)
    {
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i] == path)
                return i;
        }

         return -1;
    }
}
