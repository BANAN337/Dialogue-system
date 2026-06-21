using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;

namespace Dialogue_System.Scripts.Managers
{
    public class NodeManager
    {
        public static NodeManager Instance { get; private set; }

        public List<BaseNode> Nodes { get; } = new();

        public NodeManager()
        {
            if(Instance != null) return;
            Instance = this;
        }
    }
}
