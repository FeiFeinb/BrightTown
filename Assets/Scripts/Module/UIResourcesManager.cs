using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UI;

namespace Module
{
    public class UIResourcesManager : BaseSingletonWithMono<UIResourcesManager>
    {
        public Transform mainCanvasTrans;

        private Dictionary<string, BaseUI> _cachedDic = new Dictionary<string, BaseUI>();

        public void SeekOrSetMainCanvas(Transform canvasTrans = null)
        {
            if (canvasTrans == null)
            {
                mainCanvasTrans = GameObject.Find("Canvas").transform;
                if (mainCanvasTrans == null)
                {
                    Debug.LogError("Cant Find Canvas In Scene");
                }
            }
            else
            {
                mainCanvasTrans = canvasTrans;
            }
        }
        
        public T GetUserInterface<T>() where T : BaseUI
        {
            string uiTypeName = typeof(T).Name;
            if (_cachedDic.ContainsKey(uiTypeName))
            {
                return _cachedDic[uiTypeName] as T;
            }
            throw new NullReferenceException($"Cant Get {uiTypeName} in UICacheDictionary");
        }
        
        public GameObject LoadUserInterface(UILoadConfig loadConfig, Transform parentsTrans = null)
        {
            if (_cachedDic.ContainsKey(loadConfig.className))
                return _cachedDic[loadConfig.className].gameObject;
            GameObject result = InstantiateUserInterface(loadConfig.loadPrefab, parentsTrans);
            _cachedDic.Add(loadConfig.className, result.GetComponent<BaseUI>());
            return result;
        }

        public GameObject LoadUserInterface<T>(string storePath, Transform parentsTrans = null)
        {
            string className = typeof(T).Name;
            if (_cachedDic.ContainsKey(className))
            {
                return _cachedDic[className].gameObject;
            }
            // 加载UI 并自动创建至场景中
            GameObject tempUIRes = ResourcesManager.Instance.LoadAndInstantiate(storePath, 
                parentsTrans == null ? mainCanvasTrans : parentsTrans);
            // 属性更改
            tempUIRes.name = storePath.Substring(storePath.LastIndexOf("/") + 1);
            // 完成UI的初始化
            tempUIRes.TryGetComponent<IUserInterfacePreInit>(out IUserInterfacePreInit iPreInit);
                iPreInit?.PreInit();
            _cachedDic.Add(className, iPreInit as BaseUI);
            return tempUIRes;
        }
        
        /// <summary>
        /// 自动加载UI至给定的父节点下 并调用PreInit
        /// </summary>
        /// <param name="loadPrefab">UI预制体</param>
        /// <param name="parents">加载完成的GameObject</param>
        /// <returns></returns>
        public GameObject InstantiateUserInterface(GameObject loadPrefab, Transform parents = null)
        {
            // 克隆物件 并自动创建至场景中
            GameObject tempUIRes = GameObject.Instantiate(loadPrefab, parents == null ? mainCanvasTrans : parents);
            // 属性更改
            tempUIRes.name = loadPrefab.name;
            // 完成UI的初始化
            tempUIRes.TryGetComponent<IUserInterfacePreInit>(out IUserInterfacePreInit iPreInit);
            iPreInit?.PreInit();
            return tempUIRes;
        }
    }
}


