using System.Collections.Generic;
using DialogueSystem.GamePlay;
using Module;
using UICore;
using UnityEngine;

namespace DialogueSystem.Graph
{
    [System.Serializable]
    public class DialogueGraphChoiceNodeSaveData : DialogueGraphBaseNodeSaveData
    {
        public string Content;              // 回应内容
        public AudioClip TalkAudioClip;     // 回应音频
        
        public DialogueGraphChoiceNodeSaveData(string uniqueID, Rect rectPos, List<DialogueGraphPortSaveData> inputPortsData, List<DialogueGraphPortSaveData> outputPortsData) : base(uniqueID, rectPos, inputPortsData, outputPortsData)
        {
        }

        public override bool HandleData(DialogueTreeNode treeNode, GameObject obj)
        {
            BaseUI.GetController<InteractionController>().AddButton(InteractType.DestroyAll, Content, 
                () => CenterEvent.Instance.Raise(GlobalEventID.ContinueDialogue, UniqueID));
            return false;
        }
        
    }
}