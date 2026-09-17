using Dialogue_System.Scripts.Interfaces;
using Unity.GraphToolkit.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes
{
    public class StartingNode : BaseNode
    {
        public StartingNode(INodeSaver nodeSaver) : base(nodeSaver)
        {
            SetupNode();
        }

        protected sealed override void SetupNode()
        {
            title = "Starting Node";

            OutputPort = CreateOutputPort();
            
            outputContainer.Add(OutputPort);
            
            capabilities &= ~Capabilities.Movable;
            capabilities &= ~Capabilities.Deletable;
            
            RefreshNode();
        }
    }
}
