using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeManager : INodeSaver
    {
        public List<BaseNode> Nodes { get; } = new();

        public void SaveNode(BaseNode node)
        {
            Nodes.Add(node);
        }

        public void RemoveNode(BaseNode node)
        {
            Nodes.Remove(node);
        }
    }
}
