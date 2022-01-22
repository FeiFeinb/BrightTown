using DialogueSystem.Graph;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

namespace DialogueSystem.Editor
{
    public sealed class DialogueGraphEndNode : DialogueGraphBaseNode
    {
        public DialogueGraphEndNode(Vector2 position,
            DialogueGraphView graphView, DialogueGraphEndNodeSaveData endNodeSaveData = null) : base(position, graphView, endNodeSaveData?.UniqueID)
        {
            title = "End Node";
            AddInputPort("Parents", Port.Capacity.Multi);
            
            RefreshExpandedState();
        }

        public override bool CanConnectNode(DialogueGraphBaseNode targetNode)
        {
            return true;
        }

        public override DialogueGraphBaseNodeSaveData CreateNodeData()
        {
            DialogueGraphEndNodeSaveData endNodeSavaData = CreateBaseNodeData<DialogueGraphEndNodeSaveData>();
            return endNodeSavaData;
        }

        public override void LoadNodeData(DialogueGraphBaseNodeSaveData stateInfo)
        {
        }
    }
}