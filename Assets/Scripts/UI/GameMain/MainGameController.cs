using System.Collections;
using System.Collections.Generic;
using UICore;
using UnityEngine;

public class MainGameController : BaseUI
{
    [SerializeField] private MainGameView _mainGameView;

    protected override IEnumerable<BaseUIPanel> GetView()
    {
        yield return _mainGameView;
    }

    protected override bool InitControlObj()
    {
        base.InitControlObj();
        return true;
    }
}
