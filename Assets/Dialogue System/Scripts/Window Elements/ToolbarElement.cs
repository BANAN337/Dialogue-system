using Dialogue_System.Scripts.Window_Elements.Change_Language;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public sealed class ToolbarElement : WindowElement
    {
        public override string ElementName => "Toolbar";
        
        public readonly Toolbar Toolbar;

        public ToolbarElement(VisualElement elementContainer) : base(elementContainer)
        {
            Toolbar = elementContainer.Q<Toolbar>(ElementName);
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            Toolbar.StretchToParentSize();
        }
    }
}
