using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public sealed class ToolbarElement : WindowElement
    {
        public override string ElementName => "Toolbar";
        
        private readonly Toolbar _toolbar;

        public ToolbarElement(VisualElement elementContainer) : base(elementContainer)
        {
            _toolbar = elementContainer.Q<Toolbar>(ElementName);
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _toolbar.StretchToParentSize();
        }
    }
}
