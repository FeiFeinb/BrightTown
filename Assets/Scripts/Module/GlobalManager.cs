using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Module
{
    public class GlobalManager : BaseSingletonWithMono<GlobalManager>
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
            
            // 注册需要的回调
            GlobalEventRegister.Instance.Register();
            // 寻找Canvas
            UIResourcesManager.Instance.SeekOrSetMainCanvas();
            // 加载UI
            GlobalResourcesLoader.Instance.LoadSceneResource();
        }
    }
}