using System;
using Dialogue_System.Scripts.Managers;
using Dialogue_System.Scripts.Nodes;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class MainWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;
        
        [MenuItem("Window/Dialogue Editor")]
        public static void OpenMainWindow()
        {
            var mainWindow = GetWindow<MainWindow>();
            mainWindow.titleContent = new GUIContent("Dialogue Graph Editor");
        }

        private void CreateGUI()
        {
            SetupElements();
        }

        private void SetupElements()
        {
            tree.CloneTree(rootVisualElement);
            var toolbar = new ToolbarElement(rootVisualElement);
            var graphView = new GraphElement(rootVisualElement);
            var saveButton = new SaveButton(rootVisualElement);
            var addNode = new AddNodeMenu(rootVisualElement, graphView.Graph);
            var nodeManager = new NodeManager(graphView.Graph);
            var saveButton = new SaveButton(rootVisualElement);
            var addNode = new AddNodeMenu(rootVisualElement);
            CreateStartingNode();
        }

        private void CreateStartingNode()
        {   
            var startingNode = new StartingNode();
            NodeManager.Instance.GraphView.AddElement(startingNode);
        }
    }
}