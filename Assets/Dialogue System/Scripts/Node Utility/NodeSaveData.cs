using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeSaveData
    {
        public List<BaseNode> Nodes { get; } = new();
        public string SavedNodes { get; set; } = "";

        public NodeSaveData()
        {
            SerializeNodes();
        }
        
        public string SerializeNodes()
        {
            SavedNodes = JsonUtility.ToJson(Nodes.ToArray());
            return SavedNodes;
        }

        public List<BaseNode> DeserializeNodes()
        {
            if (string.IsNullOrEmpty(SavedNodes))
            {
                return null;
            }
            return JsonUtility.FromJson<List<BaseNode>>(SavedNodes);
        }
    }
}
