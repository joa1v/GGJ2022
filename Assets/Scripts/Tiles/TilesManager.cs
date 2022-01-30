using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TilesManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] _players;
    [SerializeField] private float _treatPercent;
    [SerializeField] private float _loadTime;
    [SerializeField] private float _treatTime;
    [SerializeField] private GameObject _treatPanel;
    [SerializeField] private GameObject _trickPanel;

    [HideInInspector] public int minigameScene;

    public Path[] paths;


    public bool TreatOrTrick()
    {
        float num = Random.Range(0f, 100f);

        if (num < _treatPercent)
            return true;
        else
            return false;
    }

    public void Treat(int id)
    {
        TreatManager.AddTreat(id, 1);
        _treatPanel.SetActive(true);
        StartCoroutine(CloseTreat(_treatTime));
    }

    public void Trick(int id)
    {
        _players[0].SavePositions();
        _players[1].SavePositions();

        _trickPanel.SetActive(true);
        StartCoroutine(LoadTrick(_loadTime));
    }

    IEnumerator LoadTrick(float loadTime)
    {
        yield return new WaitForSeconds(loadTime);
        MySceneManager.GoToScene(minigameScene);
    }

    IEnumerator CloseTreat(float loadTime)
    {
        yield return new WaitForSeconds(loadTime);
        _treatPanel.SetActive(false);
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
