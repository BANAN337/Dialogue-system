using System.Collections.Generic;
using Dialogue_System.Scripts.Node_Editor;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes.ChoiceElements
{
    public class ChoiceNodeElements : NodeElements
    {
        public TextField CharacterName { get; private set; }
        public TextField DialogueLine { get; private set; }
        public Button AddChoice { get; private set; }
        public Button RemoveChoice { get; private set; }
        
        public Stack<ChoiceData> ChoicesData { get; private set; } = new();
        
        protected override string TreePath => "Assets/Dialogue System/UXML/ChoiceNode.uxml";
        
        private const string CharacterNameTitle = "CharacterName";
        private const string DialogueLineTitle = "Text";
        private const string AddChoiceTitle = "AddChoice";
        private const string RemoveChoiceTitle = "RemoveChoice";
        
        public ChoiceNodeElements(VisualElement elementToAddTo) : base(elementToAddTo)
        {
            SetupElements();
            
            AddElementsToContainer(elementToAddTo);
        }
        
        protected sealed override void SetupElements()
        {
            CharacterName = Root.Q<TextField>(CharacterNameTitle);
            DialogueLine = Root.Q<TextField>(DialogueLineTitle);
            AddChoice = Root.Q<Button>(AddChoiceTitle);
            RemoveChoice = Root.Q<Button>(RemoveChoiceTitle);
        }

        protected sealed override void AddElementsToContainer(VisualElement element)
        {
            element.Add(Root);
        }

        
    }
}