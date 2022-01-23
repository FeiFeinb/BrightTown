﻿using Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class MainGameView : BaseUIPanel
{
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _questionnaireButton;
    
    public override void Init()
    {
        base.Init();
        _optionButton.onClick.AddListener(delegate { CenterEvent.Instance.Raise(GlobalEventID.OpenOptionView); });
        _questionnaireButton.onClick.AddListener( delegate { CenterEvent.Instance.Raise(GlobalEventID.OpenQuestionnaireView); });
    }
}