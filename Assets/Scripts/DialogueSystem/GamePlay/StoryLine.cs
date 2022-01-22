using System;
using System.Collections.Generic;
using DialogueSystem.Graph;
using UnityEngine;

namespace DialogueSystem.GamePlay
{
    public class StoryLine : MonoBehaviour
    {
        // TODO 设置对话线
        public List<DialogueGraphSO> storyList;               // 对话内容SO

        private int currentIndex = 0;
        
        public void ContinueStoryLine()
        {
            PlayerDialogueManager.Instance.StartDialogue(storyList[currentIndex++], gameObject);
        }

        public void AdvancementStoryLine()
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, storyList.Count - 1);
            // TODO 对话结束 结束游戏
        }

        public void ResetStoryLine()
        {
            currentIndex = 0;
        }

        private void Start()
        {
            ContinueStoryLine();
        }
    }
}