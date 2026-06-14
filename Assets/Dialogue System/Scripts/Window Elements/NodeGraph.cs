using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class NodeGraph : GraphView
    {
        
        
        public NodeGraph()
        {
            SetupGraph();
            SetupGrid();
            
            this.StretchToParentSize();
        }

        private void SetupGraph()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
        }

        private void SetupGrid()
        {
            var grid = new GridBackground();
            grid.name = "Background";
            
            Insert(0, grid);
            grid.StretchToParentSize();
        }
    }
}
