using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class NodeRedactor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;
        
        [MenuItem("Window/Dialogue Editor")]
        public static void OpenMainWindow()
        {
            var mainWindow = GetWindow<NodeRedactor>();
            mainWindow.titleContent = new GUIContent("Dialogue Graph Editor");
        }

        private void CreateGUI()
        {
            tree.CloneTree(rootVisualElement);
            var saveButton = new SaveButton(rootVisualElement);
            
        }
    }
}