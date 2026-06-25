using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes
{
    public class DialogueNode : BaseNode
    {
        public DialogueNode()
        {
            SetupNode();
        }

        protected override void SetupNode()
        {
            name = "Dialogue Node";
            
            var textField = new TextField("Dialogue Text");
            mainContainer.Add(textField);

            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
            inputPort.portName = "Input";
            
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.portName = "Output";
            
            inputContainer.Add(inputPort);
            outputContainer.Add(outputPort);
            
            SetPosition(Rect.zero);

            RefreshNode();
        }
    }
}
