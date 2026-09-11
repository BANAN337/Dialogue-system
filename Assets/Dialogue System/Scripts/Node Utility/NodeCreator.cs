using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using UnityEditor.Experimental.GraphView;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeCreator
    {
        private static GraphView _graphView;
        private static INodeSaver _nodeSaver;
        
        public NodeCreator(INodeSaver nodeSaver)
        {
            _graphView = GraphViewManager.CurrentGraph;
            _nodeSaver = nodeSaver;
        }

        public static StartingNode CreateStartingNode()
        {
            var startingNode = new StartingNode(_nodeSaver);
            _graphView.AddElement(startingNode);
            return startingNode;
        }

        public static ChoiceNode CreateChoiceNode()
        {
            var choiceNode = new ChoiceNode(_nodeSaver);
            _graphView.AddElement(choiceNode);
            return choiceNode;
        }
        
        public static DialogueNode CreateDialogueNode()
        {
            var dialogueNode = new DialogueNode(_nodeSaver);
            _graphView.AddElement(dialogueNode);
            return dialogueNode;
        }
    }
}
