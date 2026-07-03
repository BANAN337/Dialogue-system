using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Node_Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes
{
    public class DialogueNode : BaseNode
    {
        public DialogueNode(INodeSaver nodeSaver) : base(nodeSaver)
        {
            SetupNode();
        }

        protected override void SetupNode()
        {
            name = "Dialogue Node";

            
            
            
            
            inputContainer.Add(CreateInputPort());
            outputContainer.Add(CreateOutputPort());
            
            Add(CreateEditNodeButton());
            
            SetPosition(Rect.zero);

            RefreshNode();
        }

        private Port CreateInputPort()
        {
            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
            inputPort.portName = "Input";
            return inputPort;
        }

        private Port CreateOutputPort()
        {
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.portName = "Output";
            return outputPort;
        }

        private Button CreateEditNodeButton()
        {
            var editButton = new Button
            {
                text = "Edit"
            };

            editButton.clicked += CreateEditButton;
            
            return editButton;
        }

        private void CreateEditButton()
        {
            var editWindow = ScriptableObject.CreateInstance<EditNodeWindow>();
            editWindow.titleContent = new GUIContent("Edit Node");
            editWindow.SetupListView(DialogueLines);
            editWindow.Show();
        }
    }
}
