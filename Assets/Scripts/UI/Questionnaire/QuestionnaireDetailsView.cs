using System.Collections;
using System.Collections.Generic;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireDetailsView : BaseUIPanel
{
    [SerializeField] private Button _titleButton;
    [SerializeField] private Text _titleText;
    
    [SerializeField] private GameObject _detailsObj;

    [SerializeField] private Text _peopleSatisfactionText;

    [SerializeField] private Text _economyText;

    public override void Init()
    {
        base.Init();
        _titleButton.onClick.AddListener(delegate
        {
            _detailsObj.SetActive(!_detailsObj.activeSelf);
        });
    }

    public void RecordData(ScorePoint scorePoint, int index)
    {
        _titleText.text = $"第{index.ToString()}次问卷";
        _peopleSatisfactionText.text = scorePoint.peopleSatisfaction.ToString();
        _economyText.text = scorePoint.economy.ToString();
    }
}
