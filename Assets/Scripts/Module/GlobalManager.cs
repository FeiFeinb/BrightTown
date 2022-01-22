using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Module
{
    public class GlobalManager : BaseSingletonWithMono<GlobalManager>
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            // 加载持久资源（切换场景不销毁）
            GlobalResourcesLoader.Instance.LoadLastingResource();
            // 只需要注册一次回调 所有场景的事件都在本次注册完毕 TODO 改为更好的方法
            GlobalEventRegister.Instance.Register();
            
            // 进入场景
            CenterEvent.Instance.Raise(GlobalEventID.EnterScene);
        }
    }
}