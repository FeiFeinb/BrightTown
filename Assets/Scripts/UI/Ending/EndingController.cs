using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ManagementSystem;
using Module;
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
            var temp1 = UIResourcesManager.Instance.InstantiateUserInterface(_endingView.resultPrefab,
                _endingView.brightSideContainer.transform);
            var temp2 = UIResourcesManager.Instance.InstantiateUserInterface(_endingView.resultPrefab,
                _endingView.darkSideContainer.transform);

            var temp1View = temp1.GetComponent<EndingDetailView>();
            temp1View.CreateDetail(
                $"民生点为：{impactSo.brightSideScore.peopleSatisfaction} \n 经济点为：{impactSo.brightSideScore.economy}, ",
                true);
            var temp2View = temp2.GetComponent<EndingDetailView>();
            temp2View.CreateDetail(
                $"民生点实际为：{impactSo.darkSideScore.peopleSatisfaction} \n 经济点实际为：{impactSo.darkSideScore.economy}, ",
                false);
        }
    }
}