using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enigma", menuName = "ScriptableObjects/Enigmas", order = 1)]
public class EnigmaScriptableObject : ScriptableObject
{
    public string[] Enigmas;
    public string[] EnigmaAnswers;
}
