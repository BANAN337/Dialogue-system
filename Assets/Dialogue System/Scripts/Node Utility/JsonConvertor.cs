using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
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
            
            var json = JsonUtility.ToJson(jsonNodes.ToArray());
            
            return json;
        }

        public static NodeDto[] ConvertFromJson(string json)
        {
            var nodeDto = JsonUtility.FromJson<NodeDto[]>(json);
            return nodeDto;
        }
        
        private static NodeDto ConvertStartingNode(StartingNode startingNode)
        {
            var startingNodeDto = new NodeDto
            {
                TypeName = nameof(StartingNode),
                NodePosition = startingNode.GetPosition()
            };
        
            return startingNodeDto;
        }

        private static NodeDto ConvertDialogueNode(DialogueNode dialogueNode)
        {
            var dialogueNodeDto = new NodeDto
            {
                TypeName = nameof(DialogueNode),
                NodePosition = dialogueNode.GetPosition(),
                DialogueElement =
                {
                    DialogueLine = dialogueNode.Elements.DialogueLine.value,
                    CharacterName = dialogueNode.Elements.CharacterName.value
                }
            };

            return dialogueNodeDto;
        }
    }
}
