using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    public int currentTurn = 1;
    public bool canChangeTurn;

    public void ChangeTurns()
    {
        _players[0].turn = !_players[0].turn;
        _players[1].turn = !_players[1].turn;

        if (_players[0].turn)
            currentTurn = 1;
        else
            currentTurn = 2;
    }

}
