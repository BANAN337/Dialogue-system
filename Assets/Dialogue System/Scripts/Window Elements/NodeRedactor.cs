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
        private ToolbarButton _saveButton;
        
        [MenuItem("Window/Dialogue Editor")]
        public static void OpenMainWindow()
        {
            var mainWindow = GetWindow<NodeRedactor>();
            mainWindow.titleContent = new GUIContent("Dialogue Graph Editor");
        }

        private void CreateGUI()
        {
            tree.CloneTree(rootVisualElement);
            _saveButton = rootVisualElement.Q<ToolbarButton>("SaveButton");
            _saveButton.clicked += () =>
            {
                Debug.Log("Save");
                var path = EditorUtility.SaveFilePanel("Save Dialogue Graph", Application.dataPath, "DialogueGraph", "asset");
                Debug.Log(path);
            };
            
        }

        private void OnEnable()
        {
            //CreateToolbar();
        }

        private void CreateToolbar()
        {
            var toolbar = new Toolbar();
            var searchField = new ToolbarSearchField
            {
                value = "sercg"
            };

            var toolbarMenu = new ToolbarMenu{text = "Node types"};
            
            toolbarMenu.menu.AppendAction("button 1", _ => {Debug.Log("pressed");});
            toolbarMenu.menu.AppendAction("button 2", _ => {Debug.Log("pressed 2");});

            var menu = new GenericMenu();

        
            toolbar.Add(searchField);
            toolbar.Add(toolbarMenu);
            rootVisualElement.Add(toolbar);
        }
    }
}