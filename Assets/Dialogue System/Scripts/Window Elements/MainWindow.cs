using System;
using UnityEditor;
using UnityEditor.UIElements;
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
            tree.CloneTree(rootVisualElement);
            var mainElement = rootVisualElement.Q<VisualElement>("MainElement");
            var saveButton = new SaveButton(rootVisualElement);
            var nodeGraph = new NodeGraph(mainElement);
            mainElement.Add(nodeGraph);
            nodeGraph.StretchToParentSize();
            rootVisualElement.Add(nodeGraph);
        }
    }
}