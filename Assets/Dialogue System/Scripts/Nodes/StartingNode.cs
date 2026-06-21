using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Nodes
{
    public class StartingNode : BaseNode
    {
        public static StartingNode Instance { get; private set; } 
        
        public StartingNode()
        {
            if(Instance != null) return;
            Instance = this;
            
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
