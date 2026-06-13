using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class NodeGraph : GraphView
    {
        public NodeGraph(VisualElement parent)
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            
            var grid = new GridBackground();
            
            Insert(0, grid);
            grid.StretchToParentSize();
        }
    }
}
