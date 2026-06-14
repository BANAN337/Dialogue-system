using UnityEditor;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class GraphElement : WindowElement
    {
        public override string ElementName => "GraphElement";
        private const string StylePath = "Assets/Dialogue System/USS/Node.uss";
        public NodeGraph Graph { get; private set; }

        public GraphElement(VisualElement elementContainer) : base(elementContainer)
        {
            ConfigureElement();
            elementContainer.Insert(0, Graph);
        }

        protected sealed override void ConfigureElement()
        {
            Graph = new NodeGraph();
            Graph.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(StylePath));
        }
    }
}