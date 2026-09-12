using System.Collections.Generic;
using Dialogue_System.Scripts.Node_Editor;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.Base;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using Dialogue_System.Scripts.Nodes.Dialogue_Node;
using NUnit.Framework;
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
                nodePosition = startingNode.GetPosition()
            };
        
            return startingNodeDto;
        }

        private static NodeDto ConvertDialogueNode(DialogueNode dialogueNode)
        {
            var dialogueNodeDto = new NodeDto
            {
                typeName = nameof(DialogueNode),
                nodePosition = dialogueNode.GetPosition(),
                dialogueElement =
                {
                    dialogueLine = dialogueNode.Elements.DialogueLine.value,
                    characterName = dialogueNode.Elements.CharacterName.value
                }
            };

            return dialogueNodeDto;
        }
    }
}
