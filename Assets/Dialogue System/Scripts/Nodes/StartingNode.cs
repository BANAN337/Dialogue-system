using Dialogue_System.Scripts.Interfaces;
using Unity.GraphToolkit.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
            
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.portName = "Output";
            
            outputContainer.Add(outputPort);
            
            SetPosition(Rect.zero);
            
            RefreshNode();
        }
    }
}
