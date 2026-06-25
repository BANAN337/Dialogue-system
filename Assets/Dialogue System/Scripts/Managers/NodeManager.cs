using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Managers
{
    public class NodeManager
    {
        public static NodeManager Instance { get; private set; }

        public List<BaseNode> Nodes { get; } = new();
        
        public GraphView GraphView { get; }

        public NodeManager(GraphView graphView)
        {
            if(Instance != null) return;
            Instance = this;
            
            GraphView = graphView;
        }
    }
}
