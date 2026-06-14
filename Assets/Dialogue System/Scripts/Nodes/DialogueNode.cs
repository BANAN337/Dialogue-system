using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes
{
    public class DialogueNode : BaseNode
    {
        public DialogueNode()
        {
            SetupDialogueNode();
        }

        private void SetupDialogueNode()
        {
            var textField = new TextField("Dialogue Text");
            mainContainer.Add(textField);

            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(float));
            var outputPort = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(float));
            
            inputContainer.Add(inputPort);
            outputContainer.Add(outputPort);
            
            SetPosition(Rect.zero);
            
            RefreshExpandedState();
            RefreshPorts();
        }
    }
}
