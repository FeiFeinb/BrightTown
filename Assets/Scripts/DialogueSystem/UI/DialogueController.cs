using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DialogueSystem.Graph;
using Module;
using UICore;
using UnityEngine;

namespace DialogueSystem.UI
{
    public class DialogueController : BaseUI
    {
        [SerializeField] private DialogueView _dialogueView;

        private Coroutine _currentDialogueCoroutine;

        public void SetDialogueDisplay(DialogueCharacterInfoSO characterInfoSO, string content, string nodeUniqueID)
        {
            if (_currentDialogueCoroutine != null)
                throw new Exception("Start a new conversation while the conversation is still in progress");

            _dialogueView.SetSpeakerName(characterInfoSO.CharacterName);
            _dialogueView.SetSpeakerHead(characterInfoSO.HeadSculpture);
            _currentDialogueCoroutine = StartCoroutine(ConversationScrolling(content, nodeUniqueID));
        }

        private IEnumerator ConversationScrolling(string dialogueText, string nodeUniqueID)
        {
            float singleCharScrollTime = GameSettingConfigManager.Instance.DialogueTextSpeed;
            WaitForSeconds waitTime = new WaitForSeconds(singleCharScrollTime);
            _dialogueView.ClearContent();
            _dialogueView.SetContinueIconActive(false);

            // 等待UI动画结束才开始字幕滚动
            while (!isFinish)
            {
                yield return null;
            }
            
            foreach (char singleChar in dialogueText)
            {
                _dialogueView.AddContent(singleChar);
                yield return waitTime;
            }

            _currentDialogueCoroutine = null;

            // 对话文字播放完毕 可以继续对话
            InteractiveManager.Instance.TriggerCanContinueDialogue(nodeUniqueID);
            _dialogueView.SetContinueIconActive(true);
        }

        protected override bool AchieveDoTweenSequence()
        {
            _inSequence.Append(_dialogueView.canvasGroup.DOFade(1, 0.2f));
            _inSequence.Insert(0,
                _dialogueView.speakerHead.rectTransform.DOAnchorPosX(-_dialogueView.speakerHead.rectTransform.rect.x,
                    0.3f));
            return true;
        }

        protected override IEnumerable<BaseUIPanel> GetView()
        {
            yield return _dialogueView;
        }
    }
}