using System;
using DialogueSystem.GamePlay;
using DialogueSystem.UI;
using UICore;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Module
{
    public enum GlobalEventID
    {
        ExitGame,
        
        OpenOptionView,

        OnStartDialogue,
        OnEndDialogue,
        ContinueDialogue,

        // 音效方面
        ButtonClick,

        EnterScene,
        ExitScene,
    }

    public class GlobalEventRegister : BaseSingletonWithMono<GlobalEventRegister>
    {
        public void Register()
        {
            CenterEvent.Instance.AddListener(GlobalEventID.OnStartDialogue,
                delegate { BaseUI.GetController<DialogueController>().Show(); });
            CenterEvent.Instance.AddListener(GlobalEventID.OnEndDialogue,
                delegate { BaseUI.GetController<DialogueController>().Hide(); });

            CenterEvent.Instance.AddListener<string>(GlobalEventID.ContinueDialogue,
                delegate(string param)
                {
                    // 继续进行对话
                    PlayerDialogueManager.Instance.ContinueDialogue(param);
                    // 点击一次后禁用点击
                    InteractiveManager.Instance.SetUnableContinueDialogue();
                });


            CenterEvent.Instance.AddListener(GlobalEventID.OpenOptionView,
                delegate { BaseUI.GetController<OptionController>().Show(); });
            CenterEvent.Instance.AddListener(GlobalEventID.ExitGame, QuitGame);

            CenterEvent.Instance.AddListener(GlobalEventID.ButtonClick,
                delegate { AudioManager.Instance.PlayButtonClickSound(); });

            CenterEvent.Instance.AddListener(GlobalEventID.EnterScene, delegate
            {
                // 寻找Canvas 每次进入场景都需要进行
                UIResourcesManager.Instance.SeekOrSetMainCanvas();
                // 加载UI 每次进入场景都需要进行
                GlobalResourcesLoader.Instance.LoadSceneResource();
            });

            CenterEvent.Instance.AddListener(GlobalEventID.ExitScene, delegate
            {
                // TODO 清空加载的UI
            });
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}