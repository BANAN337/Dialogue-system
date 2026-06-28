using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeCreator
    {
        private GraphView _graphView;
        private INodeSaver _nodeSaver;
        
        public NodeCreator(GraphView graphView, INodeSaver nodeSaver)
        {
            _graphView = graphView;
            _nodeSaver = nodeSaver;
        }

        public StartingNode CreateStartingNode()
        {
            var startingNode = new StartingNode(_nodeSaver);
            _graphView.AddElement(startingNode);
            return startingNode;
        }
        
        public DialogueNode CreateDialogueNode()
        {
            var dialogueNode = new DialogueNode(_nodeSaver);
            _graphView.AddElement(dialogueNode);
            return dialogueNode;
        }
    }
}
