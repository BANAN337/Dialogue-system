using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public class EditNodeWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;

        private List<string> _dialogueLines;
        
        private const string WindowTitle = "Edit Node";
        
        private void OnEnable()
        {
            tree.CloneTree(rootVisualElement);
            titleContent = new GUIContent(WindowTitle);
        }
        
        public void SetupListView(List<string> dialogueLines)
        {
            _dialogueLines = dialogueLines;
            var listView = new DialogueLinesListView(rootVisualElement, _dialogueLines);
        }
    }
}
