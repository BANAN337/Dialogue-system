using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public abstract class WindowElement
    {
        private VisualElement _elementContainer;
        public abstract string ElementName { get; }

        protected WindowElement(VisualElement elementContainer)
        {
            _elementContainer = elementContainer;
        }
        
        protected abstract void ConfigureElement();
    }
}
