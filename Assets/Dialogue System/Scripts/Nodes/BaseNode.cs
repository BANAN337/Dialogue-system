using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using UnityEngine.UIElements;
using Node = UnityEditor.Experimental.GraphView.Node;

namespace Dialogue_System.Scripts.Nodes
{
    public abstract class BaseNode : Node
    {
        public List<string> DialogueLines = new();

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

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            _nodeSaver.RemoveNode(this);
        }
        protected abstract void SetupNode();
    }
}