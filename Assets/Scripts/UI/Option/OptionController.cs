using System.Collections.Generic;
using DG.Tweening;
using UICore;
using UnityEngine;
using UnityEngine.Serialization;

public class OptionController : BaseUI
{
    [SerializeField] private OptionView _optionView;
    
    [SerializeField] private GameSettingView _gameSettingView;
    [SerializeField] private ProductionStaffView _productionStaffView;
    
    private BaseUIPanel _currentSettingView;
    
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _selectColor;

    public override void PreInit()
    {
        base.PreInit();
        _optionView.audioSettingViewButton.onClick.AddListener(delegate { SwitchSettingView(_gameSettingView); });
        _optionView.makerViewButton.onClick.AddListener(delegate { SwitchSettingView(_productionStaffView); });
        // 默认界面
        SwitchSettingView(_gameSettingView);
    }

    protected override bool AchieveDoTweenSequence()
    {
        RectTransform rect = transform as RectTransform;
        _inSequence.Append(rect.DOAnchorPosY(-rect.anchoredPosition.y, 0.4f).SetEase(Ease.OutBack));
        return true;
    }

    protected override IEnumerable<BaseUIPanel> GetView()
    {
        yield return _optionView;
        yield return _gameSettingView;
        yield return _productionStaffView;
    }

    private void SwitchSettingView(BaseUIPanel newView)
    {
        if (_currentSettingView)
            _currentSettingView.Hide();
        _currentSettingView = newView;
        _optionView.audioSettingViewButton.image.color = _selectColor;
        _optionView.makerViewButton.image.color = _normalColor;

        _currentSettingView.Show();
    }

}