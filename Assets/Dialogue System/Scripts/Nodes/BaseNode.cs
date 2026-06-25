using System.Collections.Generic;
using Dialogue_System.Scripts.Managers;
using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using Node = UnityEditor.Experimental.GraphView.Node;

namespace Dialogue_System.Scripts.Nodes
{
    public abstract class BaseNode : Node
    {
        public List<string> DialogueLines = new();
<<<<<<< Updated upstream
=======
        
        protected BaseNode()
        {
            var nodeManager = NodeManager.Instance;
            nodeManager.GraphView.AddElement(this);
            nodeManager.Nodes.Add(this);
            RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanel);
        }
        
        protected void RefreshNode()
        {
            RefreshExpandedState();
            RefreshPorts();
        }

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            NodeManager.Instance.Nodes.Remove(this);
        }
        protected abstract void SetupNode();
>>>>>>> Stashed changes
    }
}
