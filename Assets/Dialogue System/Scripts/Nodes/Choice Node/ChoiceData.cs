using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes.Choice_Node
{
    public class ChoiceData
    {
        public Port OutputPort { get; set; }
        public TextField ChoiceText { get; set; }

        public ChoiceData(Port outputPort, TextField choiceText)
        {
            OutputPort = outputPort;
            ChoiceText = choiceText;
        }
    }
}