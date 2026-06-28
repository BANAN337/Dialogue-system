using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;
using Unity.GraphToolkit.Editor;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Managers
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
