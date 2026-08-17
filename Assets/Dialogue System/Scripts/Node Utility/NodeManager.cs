using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;
using UnityEngine;
using BaseNode = Dialogue_System.Scripts.Nodes.BaseNode;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeManager : INodeSaver
    {
        public string CurrentLanguage { get; set; }

        public Dictionary<string, NodeSaveData> NodeDictionary { get; private set; }

        public LanguagesList LanguageList {get; }

        public NodeManager(LanguagesList languageList)
        {
            LanguageList = languageList;
            
            CurrentLanguage = LanguageList.languages[0];
            
            SetupDictionary();
        }

        private void SetupDictionary()
        {
            NodeDictionary = LanguageList.languages.ToDictionary(language => language, _ => new NodeSaveData());
        }

        public void SaveNode(BaseNode node)
        {
            NodeDictionary[CurrentLanguage].Nodes.Add(node);
        }

        public void RemoveNode(BaseNode node)
        {
            NodeDictionary[CurrentLanguage].Nodes.Remove(node);
        }
    }
}