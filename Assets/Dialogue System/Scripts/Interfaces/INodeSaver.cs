using Dialogue_System.Scripts.Nodes;

namespace Dialogue_System.Scripts.Interfaces
{
    public interface INodeSaver
    {
        public void SaveNode(BaseNode node);
        public void RemoveNode(BaseNode node);
    }
}
