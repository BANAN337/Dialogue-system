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
        public DialogueNodeElements Elements { get; private set; }

        public DialogueNode(INodeSaver nodeSaver) : base(nodeSaver)
        {
            SetupNode();
        }

        protected sealed override void SetupNode()
        {
            name = NodeName;

            InputPort = CreateInputPort();
            OutputPort = CreateOutputPort();
            
            inputContainer.Add(InputPort);
            outputContainer.Add(OutputPort);

            CreateElements();

            SetPosition(Rect.zero);

            RefreshNode();
        }

        private void CreateElements()
        {
            Elements = new DialogueNodeElements(this);
        }
    }
}