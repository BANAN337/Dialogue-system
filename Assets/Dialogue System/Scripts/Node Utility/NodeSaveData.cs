using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.Base;
using Dialogue_System.Scripts.Nodes.Dialogue_Node;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeSaveData
    {
        public List<BaseNode> Nodes { get; } = new();
        private string SavedNodes { get; set; } = "";
        
        public string SerializeNodes()
        {
            SavedNodes = JsonConvertor.ConvertToJson(Nodes);
            return SavedNodes;
        }

        public NodeDtoArray DeserializeNodes()
        {
            if (string.IsNullOrEmpty(SavedNodes))
            {
                return null;
            }
            
            var convertedNodes = JsonConvertor.ConvertFromJson(SavedNodes);

            return convertedNodes;
        }
    }
}
