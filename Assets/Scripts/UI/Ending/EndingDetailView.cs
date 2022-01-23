using System.Collections;
using System.Collections.Generic;
using UICore;
using UnityEngine;
using UnityEngine.UI;

public class EndingDetailView : BaseUIPanel
{
    [SerializeField] private Text _detailText;

    public void CreateDetail(string message, bool isBrightSide)
    {
        _detailText.color = isBrightSide ? Color.black : Color.white;
        _detailText.text = message;
    }
}
