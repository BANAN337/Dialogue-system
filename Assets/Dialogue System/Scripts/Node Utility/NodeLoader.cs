using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeLoader
    {
        public static void LoadGraph(NodeSaveData nodeSaveData, GraphView graphView)
        {
            var nodes = nodeSaveData.DeserializeNodes();

            if (nodes == null)
            {
                return;
            }
            
            foreach (var node in nodes)
            {

                switch (node)
                {
                    case DialogueNode dialogueNode:
                    {
                        
                        
                        break;
                    }
                }
                
                node.SetPosition(Rect.zero);
                graphView.AddElement(node);
            }
        }
    }
}
