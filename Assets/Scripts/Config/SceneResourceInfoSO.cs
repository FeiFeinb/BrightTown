using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using Unity.Collections;
using UnityEngine;

namespace Config
{
    [Serializable]
    public class UILoadConfig
    {
        public GameObject loadPrefab;
        [DisplayOnly] public string className;
    }
    
    [CreateAssetMenu(fileName = "New SceneResourceInfoSO", menuName = "Config/SceneResourceInfoSO", order = 0)]
    public class SceneResourceInfoSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public List<UILoadConfig> configPairs = new List<UILoadConfig>();
        
        public void OnBeforeSerialize()
        {
            if (configPairs == null)
                return;
            foreach (var loadConfig in configPairs.Where(tempConfig => tempConfig.loadPrefab != null))
            {
                loadConfig.className = loadConfig.loadPrefab.GetComponent<BaseUI>().GetType().Name;
            }
        }

        public void OnAfterDeserialize()
        {
            
        }
    }
}