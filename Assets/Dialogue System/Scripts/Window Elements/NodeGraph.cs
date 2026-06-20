using System.Collections.Generic;
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
            var grid = new GridBackground
            {
                name = "Background"
            };

            Insert(0, grid);
            grid.StretchToParentSize();
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();

            foreach (var port in ports.ToList())
            {
                if (port.node == startPort.node) continue;

                if (port.direction == startPort.direction) continue;
                
                if (port.portType != startPort.portType) continue;

                compatiblePorts.Add(port);
            }

            return compatiblePorts;
        }
    }
}