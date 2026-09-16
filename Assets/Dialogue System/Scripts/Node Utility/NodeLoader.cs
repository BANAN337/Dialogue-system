using System.Collections.Generic;
using System.Linq;
using Dialogue_System.Scripts.Nodes;
using Dialogue_System.Scripts.Nodes.ChoiceElements;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dialogue_System.Scripts.Node_Utility
{
    public class NodeLoader
    {
        public static void LoadGraph(NodeSaveData nodeSaveData)
        {
            var nodeDtos = nodeSaveData.DeserializeNodes().nodeDtos;

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
