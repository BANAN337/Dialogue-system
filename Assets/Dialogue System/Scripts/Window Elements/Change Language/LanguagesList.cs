using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewLanguageList", menuName = "Language List")]
public class LanguagesList : ScriptableObject
{
    public string[] languages = {"English"};
}
