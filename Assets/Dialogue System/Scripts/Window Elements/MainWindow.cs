using System;
using Dialogue_System.Scripts.Node_Utility;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Window_Elements.Change_Language;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements
{
    public class MainWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset tree;
        private LanguagesList _languageList;

        private const string WindowTitle = "Dialogue Graph Editor";

        [MenuItem("Window/Dialogue Editor")]
        public static void OpenMainWindow()
        {
            var mainWindow = GetWindow<MainWindow>();
            mainWindow.titleContent = new GUIContent(WindowTitle);
        }

        private void CreateGUI()
        {
            _languageList = AssetDatabase.LoadAssetAtPath<LanguagesList>("Assets/Dialogue System/Language List/DefaultLanguageList.asset");
            
            SetupElements();
        }

        private void SetupElements()
        {
            tree.CloneTree(rootVisualElement);
            var toolbar = new ToolbarElement(rootVisualElement);
            var graphView = new GraphElement(rootVisualElement);
            var saveButton = new SaveButton(rootVisualElement);
            
            var nodeManager = new NodeManager(_languageList);
            var nodeCreator = new NodeCreator(nodeManager);

            SetupStartingNodes(nodeManager);
            
            var changeLanguageHandler = new ChangeLanguageHandler(nodeManager);
            var changeLanguage = new ChangeLanguage(toolbar.Toolbar, changeLanguageHandler);
            
            var addNode = new AddNodeMenu(rootVisualElement);
        }
        
        private void SetupStartingNodes(NodeManager nodeManager)
        {
            var count = 1;
            foreach (var language in nodeManager.NodeDictionary.Keys)
            {
                var value = nodeManager.NodeDictionary[language];

                if (language == nodeManager.CurrentLanguage)
                {
                    NodeCreator.CreateStartingNode();
                }
                else
                {
                    var newNode = new StartingNode(nodeManager);
                    
                    nodeManager.RemoveNode(newNode);
                    
                    value.Nodes.Add(newNode);
                    
                    value.SerializeNodes();
                    
                }
            }
        }
    }
}