using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Text _diceNum;
    [SerializeField] private Text _playerTurn;

    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Dice _dice;

    private void Update()
    {
        _playerTurn.text = "Player: " + _turnManager.currentTurn + " turn";
        _diceNum.text = "Dice: " + _dice.diceNum.ToString();
    }
}
