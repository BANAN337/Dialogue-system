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
            var json = "";
            var jsonNodes = new List<NodeDto>();

            foreach (var node in nodes)
            {
                switch (node)
                {
                    case DialogueNode dialogueNode:
                    {
                        var nodeDto = new NodeDto
                        {
                            TypeName = nameof(DialogueNode),
                            NodePosition = dialogueNode.GetPosition(),
                            DialogueElement =
                            {
                                DialogueLine = dialogueNode.Elements.DialogueLine.value,
                                CharacterName = dialogueNode.Elements.CharacterName.value
                            }
                        };
                        
                        jsonNodes.Add(nodeDto);
                        
                        break;
                    }
                }
            }
            
            return json;
        }
    }
}
