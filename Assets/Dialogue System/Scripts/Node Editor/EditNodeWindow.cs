using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public class EditNodeWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;
        
        private const string WindowTitle = "Edit Node";
        
        private void OnEnable()
        {
            tree.CloneTree(rootVisualElement);
            titleContent = new GUIContent(WindowTitle);
            Show();
        }
        
        public void SetupListView(List<DialogueElement> dialogueLines)
        {
            var listView = new DialogueLinesListView(rootVisualElement, dialogueLines);
        }
    }
}
