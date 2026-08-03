using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Interfaces;
using Dialogue_System.Scripts.Nodes;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeManager : INodeSaver
    {
        public string CurrentLanguage { get; set; }

        public List<BaseNode> Nodes { get; } = new();
        public Dictionary<string, List<BaseNode>> NodeDictionary { get; private set; }

        public LanguagesList LanguageList {get; }

        public NodeManager(LanguagesList languageList)
        {
            LanguageList = languageList;
            
            CurrentLanguage = LanguageList.languages[0];
            
            SetupDictionary();
        }

        private void SetupDictionary()
        {
            NodeDictionary = LanguageList.languages.ToDictionary(language => language, language => new List<BaseNode>());
        }

        public void SaveNode(BaseNode node)
        {
            NodeDictionary[CurrentLanguage].Add(node);
        }

        public void RemoveNode(BaseNode node)
        {
            NodeDictionary[CurrentLanguage].Remove(node);
        }
    }
}