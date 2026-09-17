using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using Dialogue_System.Scripts.Nodes.Dialogue_Node;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeLoader
    {
        private static Dictionary<string, BaseNode> _loadedNodes = new();
        private static Dictionary<string, NodeDto> _nodesToLoad = new();

        public static void Load(NodeSaveData nodeSaveData)
        {
            var nodesDto = nodeSaveData.DeserializeNodes();
            _nodesToLoad = nodesDto.nodeDtos.ToDictionary(nodeDto => nodeDto.nodeId, nodeDto => nodeDto);
            LoadNode(nodesDto.nodeDtos[0]);
        }
        
        public static void LoadNode(NodeDto nodeDto)
        {
            if (nodeDto.nodeCreated)
            {
                return;
            }
            
            switch (nodeDto.typeName)
            {
                case nameof(StartingNode):
                {
                    var newNode = NodeCreator.CreateStartingNode();
                        
                    newNode.SetPosition(nodeDto.nodePosition);
                    newNode.Id = nodeDto.nodeId;

                    _loadedNodes.TryAdd(nodeDto.nodeId, newNode);

                    if (nodeDto.outputNodeId != string.Empty && _loadedNodes.TryGetValue(nodeDto.outputNodeId, out var nodeToConnect))
                    {
                        newNode.OutputPort.ConnectTo(nodeToConnect.InputPort);
                    }
                    else if (_nodesToLoad.TryGetValue(nodeDto.outputNodeId, out var nodeToLoad))
                    {
                        LoadNode(nodeToLoad);
                    }
                    
                    break;
                }
                case nameof(DialogueNode):
                {
                    var newNode = NodeCreator.CreateDialogueNode();
                        
                    newNode.SetPosition(nodeDto.nodePosition);
                    newNode.Id = nodeDto.nodeId;

                    newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                    newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;
                        
                    _loadedNodes.TryAdd(nodeDto.nodeId, newNode);

                    if (nodeDto.outputNodeId != string.Empty && _loadedNodes.TryGetValue(nodeDto.outputNodeId, out var nodeToConnect))
                    {
                        newNode.OutputPort.ConnectTo(nodeToConnect.InputPort);
                    }
                    else if (_nodesToLoad.TryGetValue(nodeDto.outputNodeId, out var nodeToLoad))
                    {
                        LoadNode(nodeToLoad);
                    }

                    break;
                }
                
            }
        }
        
        public static void LoadGraph(NodeSaveData nodeSaveData)
        {
            var nodeDtos = nodeSaveData.DeserializeNodes().nodeDtos;
            
            var nodesDictionary = new Dictionary<NodeDto, BaseNode>();

            var nodesList = new List<BaseNode>();
            
            nodeSaveData.Nodes.Clear();

            if (nodeDtos == null)
            {
                return;
            }
            
            foreach (var nodeDto in nodeDtos)
            {
                switch (nodeDto.typeName)
                {
                    case nameof(StartingNode):
                    {
                        var newNode = NodeCreator.CreateStartingNode();
                        
                        newNode.SetPosition(nodeDto.nodePosition);
                        newNode.Id = nodeDto.nodeId;
                        
                        nodesList.Add(newNode);
                        nodesDictionary.Add(nodeDto, newNode);
                        
                        break;
                    }
                    case nameof(DialogueNode):
                    {
                        var newNode = NodeCreator.CreateDialogueNode();
                        
                        newNode.SetPosition(nodeDto.nodePosition);
                        newNode.Id = nodeDto.nodeId;

                        newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                        newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;
                        
                        nodesList.Add(newNode);
                        nodesDictionary.Add(nodeDto, newNode);
                        
                        break;
                    }
                    case nameof(ChoiceNode):
                    {
                        var newNode = NodeCreator.CreateChoiceNode();
                        
                        newNode.SetPosition(nodeDto.nodePosition);
                        newNode.Id = nodeDto.nodeId;

                        newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                        newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;


                        foreach (var choice in nodeDto.choicesData)
                        {
                            var newChoice = newNode.AddChoice();

                            newChoice.ChoiceText.value = choice.choiceText;
                        }
                        
                        nodesList.Add(newNode);
                        nodesDictionary.Add(nodeDto, newNode);

                        break;
                    }
                }
            }

            foreach (var node in nodesList)
            {
                
                
                switch (node)
                {
                    case DialogueNode dialogueNode:
                    {
                        //dialogueNode.outputContainer.Children().OfType<Port>().First().Connect();
                        
                        break;
                    }
                }
            }
        }
    }
}
