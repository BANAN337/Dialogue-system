using System.Collections.Generic;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeLoader
    {
        public static void LoadGraph(NodeSaveData nodeSaveData)
        {
            var nodeDtos = nodeSaveData.DeserializeNodes().nodeDtos;
            
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
                        
                        break;
                    }
                    case nameof(DialogueNode):
                    {
                        var newNode = NodeCreator.CreateDialogueNode();
                        
                        newNode.SetPosition(nodeDto.nodePosition);
                        newNode.Id = nodeDto.nodeId;

                        newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                        newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;
                        
                        break;
                    }
                    case nameof(ChoiceNode):
                    {
                        var newNode = NodeCreator.CreateChoiceNode();
                        
                        newNode.SetPosition(nodeDto.nodePosition);
                        newNode.Id = nodeDto.nodeId;

                        newNode.Elements.DialogueLine.value = nodeDto.dialogueElement.dialogueLine;
                        newNode.Elements.CharacterName.value = nodeDto.dialogueElement.characterName;
                        
                        

                        break;
                    }
                }
            }
        }
    }
}
