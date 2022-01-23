using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem.Graph;
using DialogueSystem.UI;
using Module;
using UICore;
using UnityEngine;

namespace DialogueSystem.GamePlay
{
    public class StoryLine : BaseSingletonWithMono<StoryLine>
    {
        // TODO 设置对话线
        public List<DialogueGraphSO> storyList;               // 对话内容SO

        private int currentIndex = 0;

        private void Start()
        {
            Invoke(nameof(ContinueStoryLine), 1.0f);
        }
        
        public void ContinueStoryLine()
        {
            if (currentIndex >= storyList.Count)
            {
                return;
            }

            if (BaseUI.GetController<DialogueController>().isActive)
            {
                return;
            }
            PlayerDialogueManager.Instance.StartDialogue(storyList[currentIndex++], gameObject);
        }

        public void ResetStoryLine()
        {
            currentIndex = 0;
        }

    }
}