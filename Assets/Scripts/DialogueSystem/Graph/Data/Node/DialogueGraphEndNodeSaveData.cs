using System.Collections.Generic;
using DialogueSystem.GamePlay;
using UnityEngine;

namespace DialogueSystem.Graph
{
    /// <summary>
    /// 结束节点数据类
    /// </summary>
    [System.Serializable]
    public class DialogueGraphEndNodeSaveData : DialogueGraphBaseNodeSaveData
    {
        public DialogueGraphEndNodeSaveData(string uniqueID, Rect rectPos, List<DialogueGraphPortSaveData> inputPortsData,
            List<DialogueGraphPortSaveData> outputPortsData) : base(uniqueID, rectPos, inputPortsData, outputPortsData)
        {
        }


        public override bool HandleData(DialogueTreeNode treeNode, GameObject obj)
        {
            PlayerDialogueManager.Instance.EndDialogue();
            return true;
        }
    }
}