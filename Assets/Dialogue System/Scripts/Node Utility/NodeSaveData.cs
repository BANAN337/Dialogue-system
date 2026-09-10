using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeSaveData
    {
        public List<BaseNode> Nodes { get; } = new();
        private string SavedNodes { get; set; } = "";
        
        public string SerializeNodes(List<BaseNode> nodes)
        {
            SavedNodes = JsonConvertor.ConvertToJson(nodes);
            return SavedNodes;
        }

        public List<BaseNode> DeserializeNodes()
        {
            if (string.IsNullOrEmpty(SavedNodes))
            {
                return null;
            }
            
            var convertedNodes = JsonConvertor.ConvertFromJson(SavedNodes);

            return null;
        }
    }
}
