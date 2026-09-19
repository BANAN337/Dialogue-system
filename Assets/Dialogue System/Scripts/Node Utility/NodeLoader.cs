using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using Dialogue_System.Scripts.Nodes.Dialogue_Node;
using Dialogue_System.Scripts.Window_Elements;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public static class NodeLoader
    {
        private static Dictionary<string, BaseNode> _loadedNodes = new();
        private static Dictionary<string, NodeDto> _nodesToLoad = new();

        public static void Load(NodeSaveData nodeSaveData)
        {
            var nodesDto = nodeSaveData.DeserializeNodes();
            _loadedNodes.Clear();
            _nodesToLoad.Clear();
            
            foreach (var nodeDto in nodesDto.nodeDtos)
            {
                _nodesToLoad.TryAdd(nodeDto.nodeId, nodeDto);
            }

            LoadNode(nodesDto.nodeDtos[0]);
        }

        private static BaseNode LoadNode(NodeDto nodeDto)
        {
            if (nodeDto.nodeCreated)
            {
                return null;
            }
            
            switch (nodeDto.typeName)
            {
                case nameof(StartingNode):
                {
                    var newNode = NodeCreator.CreateStartingNode();
                        
                    newNode.SetPosition(nodeDto.nodePosition);
                    newNode.Id = nodeDto.nodeId;

                    _loadedNodes.TryAdd(nodeDto.nodeId, newNode);

                    ConnectLoadedNode(nodeDto, newNode);
                    
                    return newNode;
                }
                case nameof(DialogueNode):
                {
                    var newNode = NodeCreator.CreateDialogueNode();
                        
                    newNode.SetPosition(nodeDto.nodePosition);
                    newNode.Id = nodeDto.nodeId;

                    newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                    newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;
                        
                    _loadedNodes.TryAdd(nodeDto.nodeId, newNode);

                    ConnectLoadedNode(nodeDto, newNode);

                    return newNode;
                }
                case nameof(ChoiceNode):
                {
                    var newNode = NodeCreator.CreateChoiceNode();

                    
                    
                    return newNode;
                }
                default:
                {
                    return null;
                }
            }
        }

        private static void ConnectLoadedNode(NodeDto nodeDto, BaseNode newNode)
        {
            if (nodeDto.outputNodeId != string.Empty && _loadedNodes.TryGetValue(nodeDto.outputNodeId, out var nodeToConnect))
            {
                var edge = newNode.OutputPort.ConnectTo(nodeToConnect.InputPort);
                GraphViewManager.CurrentGraph.AddElement(edge);
            }
            else if (_nodesToLoad.TryGetValue(nodeDto.outputNodeId, out var nodeToLoad))
            {
                var connect = LoadNode(nodeToLoad);
                var edge = newNode.OutputPort.ConnectTo(connect.InputPort);
                GraphViewManager.CurrentGraph.AddElement(edge);
            }
        }
    }
}
