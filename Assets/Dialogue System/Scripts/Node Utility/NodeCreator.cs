using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeCreator
    {
        private static GraphView _graphView;
        private static INodeSaver _nodeSaver;
        
        public NodeCreator(GraphView graphView, INodeSaver nodeSaver)
        {
            _graphView = graphView;
            _nodeSaver = nodeSaver;
        }

        public static StartingNode CreateStartingNode()
        {
            var startingNode = new StartingNode(_nodeSaver);
            _graphView.AddElement(startingNode);
            return startingNode;
        }
        
        public static DialogueNode CreateDialogueNode()
        {
            var dialogueNode = new DialogueNode(_nodeSaver);
            _graphView.AddElement(dialogueNode);
            return dialogueNode;
        }
    }
}
