using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public class DialogueNodeElements : NodeElements
    {
        public TextField CharacterName { get; private set; }
        public TextField DialogueLine { get; private set; }
        
        protected override string TreePath => "Assets/Dialogue System/UXML/ListElement.uxml";
        
        private const string CharacterNameTitle = "CharacterName";
        private const string DialogueLineTitle = "Text";

        public DialogueNodeElements(VisualElement elementToAddTo) : base(elementToAddTo)
        {
            SetupElements();

            AddElementsToContainer(elementToAddTo);
        }
        
        protected sealed override void SetupElements()
        {
            CharacterName = Root.Q<TextField>(CharacterNameTitle);
            DialogueLine = Root.Q<TextField>(DialogueLineTitle);
        }

        protected sealed override void AddElementsToContainer(VisualElement element)
        {
            element.Add(Root);
        }
    }
}
