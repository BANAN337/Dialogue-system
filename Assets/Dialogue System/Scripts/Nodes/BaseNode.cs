using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Node_Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Node = UnityEditor.Experimental.GraphView.Node;

namespace Dialogue_System.Scripts.Nodes
{
    public abstract class BaseNode : Node
    {
        public List<DialogueElement> DialogueLines { get; set; } = new();

        private readonly INodeSaver _nodeSaver;
        
        protected BaseNode(INodeSaver nodeSaver)
        {
            _nodeSaver = nodeSaver;
            _nodeSaver.SaveNode(this);
            RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanel);
        }
        
        protected void RefreshNode()
        {
            RefreshExpandedState();
            RefreshPorts();
        }
        
        protected Port CreateInputPort(string portName = "Input")
        {
            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
            inputPort.portName = portName;
            return inputPort;
        }

        protected Port CreateOutputPort(string portName = "Output")
        {
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.portName = portName;
            return outputPort;
        }

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            _nodeSaver.RemoveNode(this);
        }
        protected abstract void SetupNode();
    }
}