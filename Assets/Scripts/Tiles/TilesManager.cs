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

    public bool TreatOrTrick()
    {
        float num = Random.Range(0f, 100f);

        if (num < _threatPercent)
            return true;
        else
            return false;
    }

    public void Treat()
    {
        _trickPanel.SetActive(true);
    }

    public void Trick()
    {
        _trickPanel.SetActive(true);
        StartCoroutine(LoadTrick(_loadTime));
    }

    IEnumerator LoadTrick(float loadTime)
    {
        yield return new WaitForSeconds(loadTime);
        MySceneManager.GoToScene(minigameScene);
    }
}
