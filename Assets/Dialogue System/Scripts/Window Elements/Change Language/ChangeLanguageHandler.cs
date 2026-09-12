using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Node_Utility;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements.Change_Language
{ 
    public class ChangeLanguageHandler
    {
        private GraphView _graphView;
        private NodeManager _nodeManager;

        public List<string> Choices { get; private set; }

        public ChangeLanguageHandler(NodeManager nodeManager)
        {
            _graphView = GraphViewManager.CurrentGraph;
            _nodeManager = nodeManager;
            
            Choices = _nodeManager.NodeDictionary.Keys.ToList();
        }
        
        public void OnLanguageChange(ChangeEvent<string> changeEvent)
        {
            var newLanguage = changeEvent.newValue;
            var previousLanguage = changeEvent.previousValue;
            
            if (previousLanguage == newLanguage)
            {
                return;
            }
            
            var nodesToDelete = _nodeManager.NodeDictionary[previousLanguage].Nodes;
            
            var edgesToDelete = _graphView.edges.ToList();

            var json = _nodeManager.NodeDictionary[previousLanguage].SerializeNodes();
            
            //Debug.Log(nodesToDelete.Count);
            //Debug.Log(json);
            
            _graphView.DeleteElements(nodesToDelete);
            _graphView.DeleteElements(edgesToDelete);
            
            _nodeManager.CurrentLanguage = newLanguage;
            
            NodeLoader.LoadGraph(_nodeManager.NodeDictionary[_nodeManager.CurrentLanguage]);
        }
    }
}
