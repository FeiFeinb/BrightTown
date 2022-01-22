using System.Collections;
using System.Collections.Generic;
using Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class OptionView : BaseUIPanel
{
    public Button audioSettingViewButton;

    public Button makerViewButton;

    public Button returnButton;

    public Button quitGameButton;

    public override void Init()
    {
        base.Init();
        // 退出UI
        returnButton.onClick.AddListener(delegate { BaseUI.GetController<OptionController>().Hide(); });
        quitGameButton.onClick.AddListener(delegate { CenterEvent.Instance.Raise(GlobalEventID.ExitGame); });
    }
}