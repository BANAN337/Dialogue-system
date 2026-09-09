using Dialogue_System.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes.ChoiceElements
{
    public class ChoiceNode : BaseNode
    {
        private ChoiceNodeElements _elements;

        private VisualElement _choiceTextContainer;
        
        public ChoiceNode(INodeSaver nodeSaver) : base(nodeSaver)
        {
            SetupNode();
        }

        protected sealed override void SetupNode()
        {
            title = "Choice Node";
            
            CreateElements();
            
            AddChoiceAction();

            _elements.AddChoice.clicked += AddChoiceAction;
            _elements.RemoveChoice.clicked += RemoveChoiceAction;

            SetPosition(Rect.zero);

            RefreshNode();
        }
        
        private void CreateElements()
        {
            _elements = new ChoiceNodeElements(this);

            _choiceTextContainer = new VisualElement();
            
            topContainer.Insert(1, _choiceTextContainer);
        }
        
        private void AddChoiceAction()
        {
            var inputPort = CreateInputPort();
            var outputPort = CreateOutputPort();
            var textField = CreateChoiceTextField();
            
            inputContainer.Add(inputPort);
            outputContainer.Add(outputPort);

            _choiceTextContainer.Add(textField);
            
            _elements.ChoicesData.Push(new ChoiceData(inputPort, outputPort, textField));
        }

        private void RemoveChoiceAction()
        {
            if (_elements.ChoicesData.Count == 1)
            {
                return;
            }
            
            var choiceData = _elements.ChoicesData.Pop();
            
            inputContainer.Remove(choiceData.InputPort);
            outputContainer.Remove(choiceData.OutputPort);
            _choiceTextContainer.Remove(choiceData.ChoiceText);
        }
        
        private TextField CreateChoiceTextField()
        {
            var text = new TextField
            {
                style =
                {
                    flexGrow = 2,
                    minWidth = new StyleLength(100)
                },
                value = "filler text"
            };
            
            text.AddToClassList("my-placeholder");

            return text;
        }
    }
}
