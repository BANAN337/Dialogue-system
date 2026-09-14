using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes.Choice_Node;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes.ChoiceElements
{
    public class ChoiceNode : BaseNode
    {
        public ChoiceNodeElements Elements {get; private set;}

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

            Elements.AddChoice.clicked += AddChoiceAction;
            Elements.RemoveChoice.clicked += RemoveChoiceAction;

            SetPosition(Rect.zero);

            RefreshNode();
        }
        
        private void CreateElements()
        {
            Elements = new ChoiceNodeElements(this);

            _choiceTextContainer = new VisualElement();
            
            topContainer.Insert(1, _choiceTextContainer);
            
            var inputPort = CreateInputPort();
            inputContainer.Add(inputPort);
        }
        
        private void AddChoiceAction()
        {
            var outputPort = CreateOutputPort();
            var textField = CreateChoiceTextField();
            
            outputContainer.Add(outputPort);

            _choiceTextContainer.Add(textField);
            
            Elements.ChoicesData.Push(new ChoiceData(outputPort, textField));
        }

        private void RemoveChoiceAction()
        {
            if (Elements.ChoicesData.Count == 1)
            {
                return;
            }
            
            var choiceData = Elements.ChoicesData.Pop();
            
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
