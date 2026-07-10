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
        private List<DialogueElement> _dialogueLines;
        
        public DialogueLinesListView(VisualElement elementContainer, List<DialogueElement> dialogueLines) : base(elementContainer)
        {
            _listView = elementContainer.Q<ListView>(ElementName);
            _listView.reorderable = true;
            _dialogueLines = dialogueLines;
            ConfigureElement();
        }

        protected sealed override void ConfigureElement()
        {
            _listView.itemsSource = _dialogueLines;
            _listView.makeItem = () =>
            {
                var listElement = new EditNodeListElement();

                return listElement;
            };
            _listView.bindItem = (element, index) =>
            {
                var item = element as EditNodeListElement; 
                item?.Bind(_dialogueLines[index]);
            };
        }
    }
}
