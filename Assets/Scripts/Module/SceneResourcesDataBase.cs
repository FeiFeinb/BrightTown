using System;
using Config;
using UnityEngine;

namespace Module
{
    public class SceneResourcesDataBase : MonoBehaviour
    {
        public SceneResourceInfoSO sceneResourceInfoSO;

        // TODO: 作为切换场景的标识
        public AudioManager.BGMType bgmType;
        
        private void Start()
        {
            AudioManager.Instance.SwitchBGMSound(bgmType);
        }
    }
}