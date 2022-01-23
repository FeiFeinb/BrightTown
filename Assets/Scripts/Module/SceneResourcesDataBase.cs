using System;
using Config;
using RPG.Module;
using UnityEngine;

namespace Module
{
    public class SceneResourcesDataBase : MonoBehaviour
    {
        public SceneResourceInfoSO sceneResourceInfoSO;

        // TODO: 作为切换场景的标识
        public SceneType sceneType;
        
        private void Start()
        {
            AudioManager.Instance.SwitchBGMSound(sceneType);
        }
    }
}