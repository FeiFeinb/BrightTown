using System.Collections;
using System.Collections.Generic;
using Module;
using RPG.Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class EnterSceneView : BaseUIPanel
{
    public RectTransform chromeRect;
    public Image playerImage;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _refuseButton;


    public override void Init()
    {
        base.Init();
        chromeRect.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        // 接受则进入场景
        _acceptButton.onClick.AddListener(delegate { SceneLoader.Instance.Load("MainScene"); });
        // 拒绝则关闭窗口
        _refuseButton.onClick.AddListener(delegate { CenterEvent.Instance.Raise(GlobalEventID.ExitGame); });
    }
}
