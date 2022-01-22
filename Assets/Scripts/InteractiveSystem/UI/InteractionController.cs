using System;
using System.Collections.Generic;
using DialogueSystem.Graph;
using Module;
using UICore;
using Utility;
using UnityEngine;

public class InteractionController : BaseUI
{
    [SerializeField] private Transform _container;
    
    [SerializeField] private GameObject _interactButtonPrefab;

    public override void PreInit()
    {
        base.PreInit();
        ClearButton(true);
    }

    protected override bool InitControlObj()
    {
        base.InitControlObj();
        return true;
    }

    /// <summary>
    /// 向UI中添加互动按钮
    /// </summary>
    /// <param name="interactType">互动类型</param>
    /// <param name="content">互动按钮显示内容</param>
    /// <param name="callBack">点击按钮回调</param>
    /// <param name="buttonSprite">互动按钮Sprite 为null则默认</param>
    /// <returns>创建的互动按钮</returns>
    public InteractButton AddButton(InteractType interactType, string content, Action callBack)
    {
        InteractButton newButton;
        // 初始化交互按钮
        newButton = UIResourcesManager.Instance.InstantiateUserInterface(_interactButtonPrefab, _container).GetComponent<InteractButton>();
        switch (interactType)
        {
            case InteractType.Keep:
                break;
            case InteractType.DestroySelf:
                newButton.AddOnClickListener(delegate { newButton.Destroy(); });
                break;
            case InteractType.DestroyAll:
                newButton.AddOnClickListener(delegate { ClearButton(false); });
                break;
            default:
                throw new Exception("找不到对应的InteractButton资源");
        }
        // 添加监听
        newButton.SetInformation(content);
        newButton.AddOnClickListener(callBack);
        return newButton;
    }

    public void RemoveButton(InteractButton button)
    {
        button.Destroy();
    }

    public void HideAllButton()
    {
        _container.SetChildrenActive(false);
    }

    public void ShowAllButton()
    {
        _container.SetChildrenActive(true);
    }
    
    public void ClearButton(bool isDestroyUnActive)
    {
        _container.DestroyChildren(isDestroyUnActive);
    }
}
