using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Text _diceNum;
    [SerializeField] private TextMeshProUGUI _playerTurn;

    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Dice _dice;


    private GameObject[] _enigmas;

    private void Update()
    {
        _playerTurn.text = "Player: " + _turnManager.currentTurn + " turn";
        _diceNum.text = "Dice: " + _dice.diceNum.ToString();
    }


}
