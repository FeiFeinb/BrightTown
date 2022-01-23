using System.Collections;
using System.Collections.Generic;
using Module;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireView : BaseUIPanel
{
    [SerializeField] private Button _returnButton;

    public RectTransform detailContainer;
    
    public GameObject detailPrefab;
    
    
    public override void Init()
    {
        base.Init();
        _returnButton.onClick.AddListener(delegate
        {
            CenterEvent.Instance.Raise(GlobalEventID.CloseQuestionnaireView);
        });
    }
}
