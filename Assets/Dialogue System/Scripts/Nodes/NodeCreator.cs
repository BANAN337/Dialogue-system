using Dialogue_System.Scripts.Managers;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Nodes
{
    public class NodeCreator
    {
        private NodeManager _nodeManager;
        private GraphView _graphView;

        public NodeCreator(GraphView graphView)
        {
            _nodeManager = NodeManager.Instance;
            _graphView = graphView;
        }

        public StartingNode CreateStartingNode()
        {
            var startingNode = new StartingNode();
            AddNode(startingNode);
            return startingNode;
        }
        
        public DialogueNode CreateDialogueNode()
        {
            var node = new DialogueNode();
            AddNode(node);
            return node;
        }

        private void AddNode(BaseNode node)
        {
            _graphView.AddElement(node);
            _nodeManager.Nodes.Add(node);
        }
    }
}
