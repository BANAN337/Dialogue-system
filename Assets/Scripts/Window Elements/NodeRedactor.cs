using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Window_Elements
{
    public class NodeRedactor : EditorWindow
    {
        private EditorToolbarDropdown _createNodes;
        
        [MenuItem("Window/Dialogue Editor")]
        public static void OpenMainWindow()
        {
            var mainWindow = GetWindow<NodeRedactor>("Dialogue Editor");
            mainWindow.titleContent = new GUIContent("Dialogue Graph Editor");
        }

        private void OnEnable()
        {
            CreateToolbar();
        }

        private void OnGUI()
        {
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