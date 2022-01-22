using Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class MainGameView : BaseUIPanel
{
    [SerializeField] private Button _optionButton;

    public override void Init()
    {
        base.Init();
        _optionButton.onClick.AddListener(delegate { CenterEvent.Instance.Raise(GlobalEventID.OpenOptionView); });
    }
}