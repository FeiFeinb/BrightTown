using Config;
using UI;
using UnityEngine;

namespace Module
{
    public class GlobalResourcesLoader : BaseSingletonWithMono<GlobalResourcesLoader>
    {
        [SerializeField] private SceneResourceInfoSO _sceneResourceInfoSO;

        
        public void LoadSceneResource()
        {
            // 将需要的UI加载到场景中
            foreach (var config in _sceneResourceInfoSO.configPairs)
            {
                UIResourcesManager.Instance.LoadUserInterface(config);
            }
        }
    }
}