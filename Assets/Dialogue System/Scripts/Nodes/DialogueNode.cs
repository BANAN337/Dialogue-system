using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Node_Editor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes
{
    public class DialogueNode : BaseNode
    {
        private const string NodeName = "Dialogue Node";

        public DialogueNode(INodeSaver nodeSaver) : base(nodeSaver)
        {
            SetupNode();
        }

        protected sealed override void SetupNode()
        {
            name = NodeName;

            inputContainer.Add(CreateInputPort());
            outputContainer.Add(CreateOutputPort());

            CreateElements();

            SetPosition(Rect.zero);

            RefreshNode();
        }

        private void CreateElements()
        {
            var elements = new DialogueNodeElements(this);
        }
    }
}