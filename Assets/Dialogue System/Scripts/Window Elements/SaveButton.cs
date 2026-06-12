using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public sealed class SaveButton : ToolbarElement
    {
        public override string ElementName => "SaveButton";
        private readonly ToolbarButton _saveButton;

        public SaveButton(VisualElement elementContainer) : base(elementContainer)
        {
            _saveButton = elementContainer.Q<ToolbarButton>(ElementName);
            ConfigureElement();
        }

        protected override void ConfigureElement()
        {
            _saveButton.clicked += SaveViaPath;
        }

        private void SaveViaPath()
        {
            var path = EditorUtility.SaveFilePanel("Save Dialogue Graph", Application.dataPath, "DialogueGraph", "txt");
            Debug.Log(path);
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            File.WriteAllText(path, "sdfhhsd");
            AssetDatabase.Refresh();
        }
    }
}
