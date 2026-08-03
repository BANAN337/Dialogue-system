using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Node_Utility;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements.Change_Language
{
    public class ChangeLanguageHandler
    {
        private GraphView _graphView;
        private NodeManager _nodeManager;

        public List<string> Choices { get; private set; }

        public ChangeLanguageHandler(GraphView graphView, NodeManager nodeManager)
        {
            _graphView = graphView;
            _nodeManager = nodeManager;
            
            Choices = _nodeManager.NodeDictionary.Keys.ToList();
        }

    public void OnLanguageChange(ChangeEvent<string> changeEvent)
        {
            _graphView.DeleteElements(_nodeManager.NodeDictionary[changeEvent.previousValue]);
            
            _nodeManager.CurrentLanguage = changeEvent.newValue;
            
            //do saving next
        }
    }
}
