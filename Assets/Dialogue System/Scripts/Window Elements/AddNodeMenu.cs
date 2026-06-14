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
        private readonly GraphView _graphView;

        public AddNodeMenu(VisualElement elementContainer, GraphView graphView) : base(elementContainer)
        {
            _toolbarMenu = elementContainer.Q<ToolbarMenu>(ElementName);
            _graphView = graphView;
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _toolbarMenu.menu.AppendAction("Dialogue Node", _ =>
            {
                var dialogueNode = new DialogueNode();
                _graphView.Insert(1, dialogueNode);
            });
        }
    }
}
