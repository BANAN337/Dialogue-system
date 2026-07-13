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
            
            var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Dialogue System/UXML/ListElement.uxml");
            tree.CloneTree(this);
            
            Add(this.Q<VisualElement>("Root"));
            
            /*Add(this.Q<TextField>("CharacterName"));
            Add(this.Q<TextField>("Text"));*/
            
            Add(CreateEditNodeButton());
            
            SetPosition(Rect.zero);

            RefreshNode();
        }

        private TextField CharacterName()
        {
            var characterName = new TextField
            {
                label = "Character Name"
            };

            return characterName;
        }
        
        private TextField DialogueLine()
        {
            var characterName = new TextField
            {
                label = "Text",
                //style = { width = 100},
                multiline = true,
                
            };

            return characterName;
        }

        private Button CreateEditNodeButton()
        {
            var editButton = new Button
            {
                text = "Edit",
            };

            editButton.clicked += CreateEditWindow;
            
            return editButton;
        }

        private void CreateEditWindow()
        {
            var editWindow = ScriptableObject.CreateInstance<EditNodeWindow>();
            editWindow.SetupListView(DialogueLines);
        }
    }
}
