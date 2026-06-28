using System;
using Dialogue_System.Scripts.Managers;
using Dialogue_System.Scripts.Node_Utility;
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
            
            var nodeManager = new NodeManager();
            var nodeCreator = new NodeCreator(graphView.Graph, nodeManager);
            
            var addNode = new AddNodeMenu(rootVisualElement, nodeCreator);
            
            var startingNode = nodeCreator.CreateStartingNode();
        }
    }
}