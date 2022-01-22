using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UICore;
using UnityEngine;

public class EnterSceneController : BaseUI
{
    [SerializeField] private EnterSceneView _enterSceneView;

    protected override IEnumerable<BaseUIPanel> GetView()
    {
        yield return _enterSceneView;
    }

    protected override bool AchieveDoTweenSequence()
    {
        _inSequence.Append(_enterSceneView.chromeRect.DOScale(new Vector3(1, 1, 1), 0.15f));
        _inSequence.Append(_enterSceneView.playerImage.rectTransform.
            DOAnchorPosX(-_enterSceneView.chromeRect.rect.x, 0.3f));
        return true;
    }
}
