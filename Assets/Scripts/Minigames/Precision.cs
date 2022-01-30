using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Precision : MonoBehaviour
{
    [SerializeField] private Indicator _indicator;
    [SerializeField] private GameObject _spider;
    [SerializeField] private Vector3 _spiderMove;

    [SerializeField] private Transform _maxY;
    [SerializeField] private Transform _minY;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToWait;

    [SerializeField] private GameObject[] areas;
    [SerializeField] private int maxRounds;
    private int roundId;

    private bool moveBottom = true;

    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private GameObject _winPanel;

    private int currentPlayerId;
    private bool startGame;

    private void Start()
    {
        currentPlayerId = PlayerPrefs.GetInt("CurrentMinigamePlayerId");

        StartCoroutine(Wait(_timeToWait));

    }

    private void Update()
    {
        if (startGame)
        {
            MoveIndicator();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_indicator.inArea)
                {
                    roundId++;
                    if (roundId < maxRounds)
                    {
                        MoveSpider();
                        NextRound();
                    }
                    else
                    {
                        MoveSpider();
                        TreatManager.AddTreat(currentPlayerId, 1);
                        _winPanel.SetActive(true);
                    }

                }
                else if (!_indicator.inArea && roundId < maxRounds)
                    _loosePanel.SetActive(true);
            }
        }

    }

    private void MoveIndicator()
    {
        Transform indTransform = _indicator.transform;
        if (indTransform.position.y == _minY.position.y && moveBottom)
        {
            moveBottom = false;
        }
        else if (indTransform.position.y == _maxY.position.y && !moveBottom)
        {
            moveBottom = true;
        }

        if (moveBottom)
        {
            MoveBottom();
        }
        else
        {
            MoveTop();
        }
    }

    private void MoveBottom()
    {
        Transform indTransform = _indicator.transform;

        Vector3 minPos = new Vector3(indTransform.position.x, _minY.transform.position.y, _indicator.transform.position.z);

        _indicator.transform.position = Vector3.MoveTowards(indTransform.position, minPos, _speed);
    }

    private void MoveTop()
    {
        Transform indTransform = _indicator.transform;

        Vector3 maxPos = new Vector3(indTransform.position.x, _maxY.transform.position.y, _indicator.transform.position.z);

        _indicator.transform.position = Vector3.MoveTowards(indTransform.position, maxPos, _speed);

    }

    private void NextRound()
    {
        for (int i = 0; i < areas.Length; i++)
        {
            areas[i].SetActive(false);
            if (i == roundId)
            {
                areas[i].SetActive(true);
            }
        }

    }

    private void MoveSpider()
    {
        _spider.transform.position += _spiderMove;

    }


    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        startGame = true;
    }


}
