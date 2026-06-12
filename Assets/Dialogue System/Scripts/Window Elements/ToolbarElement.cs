using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public abstract class ToolbarElement
    {
        private VisualElement _elementContainer;
        public abstract string ElementName { get; }

        protected ToolbarElement(VisualElement elementContainer)
        {
            _elementContainer = elementContainer;
        }
        
        protected abstract void ConfigureElement();
    }
}
