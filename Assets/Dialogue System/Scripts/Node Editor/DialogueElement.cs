using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    [Serializable]
    public class DialogueElement
    {
        public string characterName;
        public string dialogueLine;
    }
}