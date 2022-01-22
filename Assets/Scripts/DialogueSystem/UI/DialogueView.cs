using System;
using System.Collections;
using System.Collections.Generic;
using Module;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem.UI
{
    public class DialogueView : BaseUIPanel
    {
        public Image speakerHead;
        public Text speakerName;
        public Text content;

        public void SetSpeakerHead(Sprite newSpeakerHead)
        {
            speakerHead.sprite = newSpeakerHead;
        }

        public void SetSpeakerName(string newSpeakerName)
        {
            speakerName.text = newSpeakerName;
        }

        public void AddContent(char newChar)
        {
            content.text += newChar;
        }

        public void ClearContent()
        {
            content.text = String.Empty;
        }
    }
}

