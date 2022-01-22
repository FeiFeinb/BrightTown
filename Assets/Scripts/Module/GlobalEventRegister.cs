using System;
using DialogueSystem.GamePlay;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Module
{
    public enum GlobalEventID
    {
        ExitGame,
        ContinueDialogue
    }

    public class GlobalEventRegister : BaseSingletonWithMono<GlobalEventRegister>
    {
        public void Register()
        {
            CenterEvent.Instance.AddListener<string>(GlobalEventID.ContinueDialogue, PlayerDialogueManager.Instance.ContinueDialogue);

            CenterEvent.Instance.AddListener(GlobalEventID.ExitGame, QuitGame);
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