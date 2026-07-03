using System.Collections.Generic;
using Dialogue_System.Scripts.Window_Elements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public class DialogueLinesListView : WindowElement
    {
        public sealed override string ElementName { get; } = "DialogueLines";
        
        private readonly ListView _listView;
        private readonly List<string> _dialogueLines;
        
        public DialogueLinesListView(VisualElement elementContainer, List<string> dialogueLines) : base(elementContainer)
        {
            _listView = elementContainer.Q<ListView>(ElementName);
            _dialogueLines = dialogueLines;
            ConfigureElement();
        }

        protected sealed override void ConfigureElement()
        {
            _listView.itemsSource = _dialogueLines;
        }
    }
}
