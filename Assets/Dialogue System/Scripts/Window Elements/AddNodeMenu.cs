using Dialogue_System.Scripts.Managers;
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
        private readonly NodeCreator _nodeCreator;
        
        public AddNodeMenu(VisualElement elementContainer, NodeCreator creator) : base(elementContainer)
        {
            _toolbarMenu = elementContainer.Q<ToolbarMenu>(ElementName);
            _nodeCreator = creator;
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _toolbarMenu.menu.AppendAction("Dialogue Node", _ =>
            {
                _nodeCreator.CreateDialogueNode();
            });
        }
    }
}
