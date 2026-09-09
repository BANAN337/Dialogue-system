using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Nodes.ChoiceElements
{
    public class ChoiceData
    {
        public Port InputPort { get; set; }
        public Port OutputPort { get; set; }
        public TextField ChoiceText { get; set; }

        public ChoiceData(Port inputPort, Port outputPort, TextField choiceText)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
            ChoiceText = choiceText;
        }
    }
}