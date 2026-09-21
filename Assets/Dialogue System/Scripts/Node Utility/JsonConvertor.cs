using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Node_Editor;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.Base;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using Dialogue_System.Scripts.Nodes.Dialogue_Node;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public static class JsonConvertor
    {
        public static string ConvertToJson(List<BaseNode> nodes)
        {
            var jsonNodes = new List<NodeDto>();
            
            foreach (var node in nodes)
            {
                switch (node)
                {
                    case StartingNode startingNode:
                    {
                        jsonNodes.Add(ConvertStartingNode(startingNode));
                        
                        break;
                    }
                    case DialogueNode dialogueNode:
                    {
                        jsonNodes.Add(ConvertDialogueNode(dialogueNode));
                        
                        break;
                    }
                    case ChoiceNode choiceNode:
                    {
                        jsonNodes.Add(ConvertChoiceNode(choiceNode));
                        
                        break;
                    }
                }
            }

            var serializableArray = new NodeDtoArray
            {
                nodeDtos = jsonNodes.ToArray()
            };

            var json = JsonUtility.ToJson(serializableArray);
            
            return json;
        }

        public static NodeDtoArray ConvertFromJson(string json)
        {
            var nodeDto = JsonUtility.FromJson<NodeDtoArray>(json);
            return nodeDto;
        }
        
        private static NodeDto ConvertStartingNode(StartingNode startingNode)
        {
            var startingNodeDto = new NodeDto
            {
                typeName = nameof(StartingNode),
                nodeId = startingNode.Id,
                nodePosition = startingNode.GetPosition()
            };

            AddOutputNodeId(startingNode, startingNodeDto);
        
            return startingNodeDto;
        }

        private static NodeDto ConvertDialogueNode(DialogueNode dialogueNode)
        {
            var dialogueNodeDto = new NodeDto
            {
                typeName = nameof(DialogueNode),
                nodeId = dialogueNode.Id,
                nodePosition = dialogueNode.GetPosition(),
                dialogueElement =
                {
                    dialogueLine = dialogueNode.Elements.DialogueLine.value,
                    characterName = dialogueNode.Elements.CharacterName.value
                }
            };
            
            AddOutputNodeId(dialogueNode, dialogueNodeDto);
            AddInputNodeIds(dialogueNode, dialogueNodeDto);

            return dialogueNodeDto;
        }

        private static NodeDto ConvertChoiceNode(ChoiceNode choiceNode)
        {
            var choiceNodeDto = new NodeDto
            {
                typeName = nameof(ChoiceNode),
                nodeId = choiceNode.Id,
                nodePosition = choiceNode.GetPosition(),
                dialogueElement =
                {
                    dialogueLine = choiceNode.Elements.DialogueLine.value,
                    characterName = choiceNode.Elements.CharacterName.value
                }
            };
            
            AddChoiceNodeIds(choiceNode, choiceNodeDto);
            
            return choiceNodeDto;
        }

        private static NodeDto AddInputNodeIds(BaseNode node, NodeDto nodeDto)
        {
            var inputNodesId = new List<string>();
            
            foreach (var port in node.inputContainer.Children().OfType<Port>())
            {
                foreach (var edge in port.connections)
                {
                    var connectedNode = (BaseNode)edge.output.node;
                    inputNodesId.Add(connectedNode.Id);
                }
            }
            
            nodeDto.inputNodesId = inputNodesId.ToArray();
            
            return nodeDto;
        }

        private static NodeDto AddOutputNodeId(BaseNode node, NodeDto nodeDto)
        {
            foreach (var port in node.outputContainer.Children().OfType<Port>())
            {
                foreach (var edge in port.connections)
                {
                    var connectedNode = (BaseNode)edge.input.node;
                    nodeDto.outputNodeId = connectedNode.Id;
                }
            }
            
            return nodeDto;
        }

        private static NodeDto AddChoiceNodeIds(ChoiceNode node, NodeDto nodeDto)
        {
            var inputNodesId = new List<string>();
            var choicesData = new List<ChoiceDataDto>();
            
            AddInputNodeIds(node, nodeDto);

            foreach (var choiceData in node.Elements.ChoicesData)
            {
                var connectedNode = (BaseNode)choiceData.OutputPort.connections.FirstOrDefault()?.input.node;
                
                var newChoicesData = new ChoiceDataDto
                {
                    choiceText = choiceData.ChoiceText.value
                };

                if (connectedNode != null)
                {
                    newChoicesData.outputNodeId = connectedNode.Id;
                }

                choicesData.Add(newChoicesData);
            }

            choicesData.Reverse();
            
            nodeDto.choicesDataDto = choicesData.ToArray();

            return nodeDto;
        }
    }
}
