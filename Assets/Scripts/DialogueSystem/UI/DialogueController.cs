using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem.GamePlay;
using DialogueSystem.Graph;
using UI;
using UnityEngine;

namespace DialogueSystem.UI
{
    public class DialogueController: BaseUI
    {
        [SerializeField] private float singleCharScrollTime = 0.1f;
        
        [SerializeField] private DialogueView _dialogueView;

        private Coroutine _currentDialogueCoroutine;

        public void SetDialogueDisplay(DialogueCharacterInfoSO characterInfoSO, string content, string nodeUniqueID)
        {
            if (_currentDialogueCoroutine != null)
                throw new Exception("Start a new conversation while the conversation is still in progress");
            
            _dialogueView.SetSpeakerHead(characterInfoSO.HeadSculpture);
            _dialogueView.SetSpeakerName(characterInfoSO.CharacterName);
            _currentDialogueCoroutine = StartCoroutine(ConversationScrolling(content, nodeUniqueID));
        }

        private IEnumerator ConversationScrolling(string dialogueText, string nodeUniqueID)
        {
            WaitForSeconds waitTime = new WaitForSeconds(singleCharScrollTime);
            _dialogueView.ClearContent();
            foreach (char singleChar in dialogueText)
            {
                _dialogueView.AddContent(singleChar);
                yield return waitTime;
            }

            _currentDialogueCoroutine = null;

            // 对话文字播放完毕 可以继续对话
            InteractiveManager.Instance.TriggerCanContinueDialogueOnce(nodeUniqueID);
        }
        
    }
}