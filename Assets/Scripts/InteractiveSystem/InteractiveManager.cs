using System;
using System.Collections;
using System.Collections.Generic;
using Module;
using UnityEngine;

public class InteractiveManager : BaseSingletonWithMono<InteractiveManager>
{
    private bool canDialogueContinue = false;
    private string dialogueUniqueID = String.Empty;
    
    public void TriggerCanContinueDialogueOnce(string uniqueID, bool isEnable = true)
    {
        dialogueUniqueID = uniqueID;
        canDialogueContinue = isEnable;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canDialogueContinue && dialogueUniqueID != String.Empty)
        {
            CenterEvent.Instance.Raise(GlobalEventID.ContinueDialogue, dialogueUniqueID);
            // 点击一次后禁用点击
            TriggerCanContinueDialogueOnce(String.Empty, false);
        }
    }
}
