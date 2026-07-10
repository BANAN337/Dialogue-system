using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public class EditNodeListElement : VisualElement
    {
        public TextField CharacterName { get; private set; }
        public TextField DialogueLine { get; private set; }

        public EditNodeListElement()
        {
            var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Dialogue System/UXML/ListElement.uxml");
            
            tree.CloneTree(this);

            CharacterName = this.Q<TextField>("CharacterName");
            DialogueLine = this.Q<TextField>("Text");
        }

        public void Bind(DialogueElement dialogueElement)
        {
            if (dialogueElement == null)
            {
                dialogueElement = new DialogueElement();
            }
            
            CharacterName.value = dialogueElement.CharacterName;
            DialogueLine.value = dialogueElement.DialogueLine;
        }
    }
}