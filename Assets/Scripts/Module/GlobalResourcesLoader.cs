using Config;
using UICore;
using UnityEngine;

namespace Module
{
    public class GlobalResourcesLoader : BaseSingletonWithMono<GlobalResourcesLoader>
    {
        public void LoadLastingResource()
        {
            // 加载场景加载的UI
            UIResourcesManager.Instance.LoadUserInterface<SceneLoadingController>("UIView/SceneLoadingView",
                UIResourcesManager.Instance.lastingCanvasTrans);
        }
        
        public void LoadSceneResource()
        {
            // 找到场景中需要加载的数据
            SceneResourcesDataBase sceneResourceInfoSO = FindObjectOfType(typeof(SceneResourcesDataBase)) 
                as SceneResourcesDataBase;
            if (sceneResourceInfoSO == null) 
                return;
            // 将需要的UI加载到场景中
            foreach (var config in sceneResourceInfoSO.sceneResourceInfoSO.configPairs)
                 UIResourcesManager.Instance.LoadUserInterface(config);
        }
    }
}