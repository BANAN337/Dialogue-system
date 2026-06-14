using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine.VFX;
using Node = UnityEditor.Experimental.GraphView.Node;

namespace Dialogue_System.Scripts.Nodes
{
    public abstract class BaseNode : Node
    {
        public List<string> DialogueLines = new();
    }
}
