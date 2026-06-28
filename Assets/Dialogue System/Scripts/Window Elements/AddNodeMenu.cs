using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Managers;
using Dialogue_System.Scripts.Node_Utility;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public sealed class AddNodeMenu : WindowElement
    {
        public override string ElementName => "AddNode";
        
        private readonly ToolbarMenu _toolbarMenu;
        private NodeCreator _nodeCreator;
        
        public AddNodeMenu(VisualElement elementContainer, NodeCreator nodeCreator) : base(elementContainer)
        {
            _nodeCreator = nodeCreator;
            _toolbarMenu = elementContainer.Q<ToolbarMenu>(ElementName);
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _toolbarMenu.menu.AppendAction("Dialogue Node", _ =>
            {
                var dialogueNode = _nodeCreator.CreateDialogueNode();
            });
        }
    }
}
