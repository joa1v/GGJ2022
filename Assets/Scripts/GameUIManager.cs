using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    //[SerializeField] private Text _diceNum;
    [SerializeField] private TextMeshProUGUI _playerTurn;

    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Dice _dice;

    [SerializeField] private TextMeshProUGUI[] _enigmas;

    [SerializeField] private EnigmaScriptableObject[] _enigmaData;
    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        UpdateEnigma();
    }

    private void Update()
    {
        _playerTurn.text = "Player: " + _turnManager.currentTurn;
        //_diceNum.text = _dice.diceNum.ToString();
    }

    public void ActiveEnigma(int enigmaID)
    {
        for (int i = 0; i < _enigmas.Length; i++)
        {
            _enigmas[i].gameObject.SetActive(false);

            if (i == enigmaID)
                _enigmas[i].gameObject.SetActive(true);
        }
    }


    public void UpdateEnigma()
    {
        int player1Treats = PlayerPrefs.GetInt("Player0Treat");
        int player2Treats = PlayerPrefs.GetInt("Player1Treat");

        for (int i = 0; i < _enigmaData[0].Enigmas.Length; i++)
        {
            string enig = i < player1Treats ? _enigmaData[0].EnigmaAnswers[i] : _enigmaData[0].Enigmas[i];
            _enigmas[0].text += " | " + enig;
        }

        for (int i = 0; i < _enigmaData[1].Enigmas.Length; i++)
        {
            string enig = i < player2Treats ? _enigmaData[1].EnigmaAnswers[i] : _enigmaData[1].Enigmas[i];
            _enigmas[1].text += " | " + enig;
        }

        if (player1Treats >= 6)
        {
            gm.Win(1);
        }

        if (player2Treats >= 6)
        {
            gm.Win(2);
        }
    }


}
