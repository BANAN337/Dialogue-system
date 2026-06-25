using Dialogue_System.Scripts.Nodes;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public sealed class AddNodeMenu : WindowElement
    {
        public override string ElementName => "AddNode";
        
        private readonly ToolbarMenu _toolbarMenu;
<<<<<<< Updated upstream
        private readonly GraphView _graphView;

        public AddNodeMenu(VisualElement elementContainer, GraphView graphView) : base(elementContainer)
        {
            _toolbarMenu = elementContainer.Q<ToolbarMenu>(ElementName);
            _graphView = graphView;
=======
        
        public AddNodeMenu(VisualElement elementContainer) : base(elementContainer)
        {
            _toolbarMenu = elementContainer.Q<ToolbarMenu>(ElementName);
>>>>>>> Stashed changes
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _toolbarMenu.menu.AppendAction("Dialogue Node", _ =>
            {
                var dialogueNode = new DialogueNode();
<<<<<<< Updated upstream
                _graphView.AddElement(dialogueNode);
=======
                Debug.Log(NodeManager.Instance.Nodes.Count);
>>>>>>> Stashed changes
            });
        }
    }
}
