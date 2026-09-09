using System;
using Dialogue_System.Scripts.Node_Editor;
using Dialogue_System.Scripts.Node_Utility;
using Dialogue_System.Scripts.Nodes.Base;
using UnityEditor.Categorization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogue_System.Scripts.Nodes.Dialogue_Node
{
    [Serializable]
    public class NodeDto
    {
        public string TypeName { get; set; }
        public DialogueElement DialogueElement { get; set; }
        public Rect NodePosition { get; set; }
        public string[] ChoicesText { get; set; }
    }
}