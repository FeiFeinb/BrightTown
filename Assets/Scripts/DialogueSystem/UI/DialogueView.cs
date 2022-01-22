using System;
using UICore;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem.UI
{
    public class DialogueView : BaseUIPanel
    {
        public Image speakerHead;
        public Text speakerName;
        public Text content;
        public CanvasGroup canvasGroup;
        public Image continueImage;
        
        
        public override void Init()
        {
            base.Init();
            canvasGroup.alpha = 0;
            continueImage.gameObject.SetActive(false);
        }

        public void SetSpeakerHead(Sprite newSpeakerHead)
        {
            speakerHead.sprite = newSpeakerHead;
        }

        public void SetSpeakerName(string newSpeakerName)
        {
            speakerName.text = newSpeakerName;
        }

        public void SetContinueIconActive(bool newIsActive)
        {
            continueImage.gameObject.SetActive(newIsActive);
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

