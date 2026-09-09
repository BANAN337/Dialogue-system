using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Node_Utility;
using Dialogue_System.Scripts.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
            var nodesToDelete = _nodeManager.NodeDictionary[changeEvent.previousValue].Nodes;
            
            var edgesToDelete = _graphView.edges.ToList();

            var json = _nodeManager.NodeDictionary[changeEvent.previousValue].SerializeNodes(nodesToDelete);
            
            Debug.Log(nodesToDelete.Count);
            Debug.Log(json);
            
            _graphView.DeleteElements(nodesToDelete);
            _graphView.DeleteElements(edgesToDelete);
            
            _nodeManager.CurrentLanguage = changeEvent.newValue;
            
            NodeLoader.LoadGraph(_nodeManager.NodeDictionary[_nodeManager.CurrentLanguage], _graphView);
        }
    }
}
