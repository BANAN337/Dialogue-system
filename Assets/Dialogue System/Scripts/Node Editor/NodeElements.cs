using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Node_Editor
{
    public abstract class NodeElements
    {
        protected VisualElement Root;
        protected abstract string TreePath { get; }

        private VisualTreeAsset _tree;
        
        public NodeElements(VisualElement elementToAddTo)
        {
            LoadTree();
            Root = new VisualElement();
            _tree.CloneTree(Root);
        }

        protected void LoadTree()
        {
            _tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(TreePath);
        }

        protected abstract void SetupElements();
        
        protected abstract void AddElementsToContainer(VisualElement element);
    }
}
