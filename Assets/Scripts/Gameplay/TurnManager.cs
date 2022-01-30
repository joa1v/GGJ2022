using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    [SerializeField] private GameUIManager _gameUiManager;
    [SerializeField] private GameObject _p1Light;
    [SerializeField] private GameObject _p2Light;
    public int currentTurn = 1;
    public bool canChangeTurn;
    public static bool canMove = true;
    static bool player1WasLast;

    private void Start()
    {
        if (player1WasLast)
        {
            ChangeTurns();
        }
    }

    public void ChangeTurns()
    {
        _players[0].turn = !_players[0].turn;
        _players[1].turn = !_players[1].turn;

        if (_players[0].turn)
        {
            currentTurn = 1;
            _p1Light.SetActive(true);
            _p2Light.SetActive(false);
        }
        else
        {
            currentTurn = 2;
            _p1Light.SetActive(false);
            _p2Light.SetActive(true);
        }
        _gameUiManager.ActiveEnigma(currentTurn - 1);

        _gameUiManager.UpdateEnigma();
    }

    public void CheckTurns()
    {
        if (_players[0].turn)
        {
            player1WasLast = true;
        }
        else
        {
          player1WasLast = false;
        }
    }
        



}
