using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem.UI;
using Module;
using UICore;
using UnityEngine;

public class InteractiveManager : BaseSingletonWithMono<InteractiveManager>
{
    private bool canDialogueContinue = false;
    private string dialogueUniqueID = String.Empty;
    
    public void TriggerCanContinueDialogue(string uniqueID)
    {
        dialogueUniqueID = uniqueID;
        canDialogueContinue = true;
    }

    public void SetUnableContinueDialogue()
    {
        dialogueUniqueID = String.Empty;
        canDialogueContinue = false;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canDialogueContinue && dialogueUniqueID != String.Empty)
        {
            CenterEvent.Instance.Raise(GlobalEventID.ContinueDialogue, dialogueUniqueID);

        }
    }
}
