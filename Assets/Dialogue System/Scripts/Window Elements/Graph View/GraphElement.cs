using UnityEditor;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class GraphElement : WindowElement
    {
        public override string ElementName => "GraphElement";
        private const string StylePath = "Assets/Dialogue System/USS/Node.uss";
        
        private GraphViewManager _graphManager;

        public GraphElement(VisualElement elementContainer) : base(elementContainer)
        {
            ConfigureElement();
            elementContainer.Insert(0, GraphViewManager.CurrentGraph);
        }

        protected sealed override void ConfigureElement()
        {
            _graphManager = new GraphViewManager();
        }
    }
}