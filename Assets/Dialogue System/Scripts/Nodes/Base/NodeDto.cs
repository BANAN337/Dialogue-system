using System;
using Dialogue_System.Scripts.Node_Editor;
using Dialogue_System.Scripts.Node_Utility;
using Dialogue_System.Scripts.Nodes.Base;
using Dialogue_System.Scripts.Nodes.Choice_Node;
using UnityEditor.Categorization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogue_System.Scripts.Nodes.Dialogue_Node
{
    [Serializable]
    public class NodeDto
    {
        public string nodeId;
        public string[] inputNodesId;
        public string outputNodeId = string.Empty;
        
        public string typeName;
        public DialogueElement dialogueElement = new();
        public Rect nodePosition;
        
        public ChoiceDataDto[] choicesData;
        
        public bool nodeCreated;
    }
}