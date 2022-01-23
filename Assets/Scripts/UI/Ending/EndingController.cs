using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ManagementSystem;
using UICore;
using UnityEngine;

public class EndingController : BaseUI
{
    [SerializeField] private EndingView _endingView;

    protected override IEnumerable<BaseUIPanel> GetView()
    {
        yield return _endingView;
    }

    protected override bool AchieveDoTweenSequence()
    {
        RectTransform rect = transform as RectTransform;
        _inSequence.Append(rect.DOAnchorPosY(-rect.anchoredPosition.y, 0.4f).SetEase(Ease.OutBack));
        return true;
    }

    public void CreateEndingResult(List<ChoiceImpactSO> resultList)
    {
        foreach (ChoiceImpactSO impactSo in resultList)
        {
            
        }
    }
}
