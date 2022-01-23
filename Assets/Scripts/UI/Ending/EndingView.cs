using Module;
using RPG.Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class EndingView : BaseUIPanel
{
    public GameObject brightSideContainer;

    public GameObject darkSideContainer;

    public GameObject resultPrefab;
    
    [SerializeField] private Button _restartButton;

    public override void Init()
    {
        base.Init();
        _restartButton.onClick.AddListener(delegate
        {
            CenterEvent.Instance.Raise(GlobalEventID.CloseEndingView);
        });
    }
}
