using Dialogue_System.Scripts.Window_Elements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphViewManager
{
    public static NodeGraph CurrentGraph { get; private set; }
    private const string StylePath = "Assets/Dialogue System/USS/Node.uss";

    public GraphViewManager()
    {
        CurrentGraph = new NodeGraph();
        CurrentGraph.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(StylePath));
    }
}
