using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Module;
using UICore;
using UnityEngine;

public class QuestionnaireController : BaseUI
{
    [SerializeField] private QuestionnaireView _questionnaireView;
    
    protected override IEnumerable<BaseUIPanel> GetView()
    {
        yield return _questionnaireView;
    }
    
    protected override bool AchieveDoTweenSequence()
    {
        RectTransform rect = transform as RectTransform;
        _inSequence.Append(rect.DOAnchorPosY(-rect.anchoredPosition.y, 0.4f).SetEase(Ease.OutBack));
        return true;
    }
    
    public void CreateQuestionnaireDetail(ScorePoint scorePoint, int index)
    {
        GameObject newDetail = UIResourcesManager.Instance.InstantiateUserInterface(_questionnaireView.detailPrefab,
            _questionnaireView.detailContainer);
        var detailView = newDetail.GetComponent<QuestionnaireDetailsView>();
        if (detailView != null)
        {
            detailView.RecordData(scorePoint, index);
        }
    }
    
}
