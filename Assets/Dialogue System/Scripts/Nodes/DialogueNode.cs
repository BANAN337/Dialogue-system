using System.Collections.Generic;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Node_Editor;
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
            
            Add(CreateEditNodeButton());
            
            SetPosition(Rect.zero);

            RefreshNode();
        }

        private Button CreateEditNodeButton()
        {
            var editButton = new Button
            {
                text = "Edit"
            };

            editButton.clicked += CreateEditButton;
            
            return editButton;
        }

        private void CreateEditButton()
        {
            var editWindow = ScriptableObject.CreateInstance<EditNodeWindow>();
            editWindow.SetupListView(DialogueLines);
        }
    }
}
