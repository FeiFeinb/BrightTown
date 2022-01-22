using System;
using UnityEngine;

[Serializable]
public class ScorePoint
{
    /// <summary>
    /// 民生
    /// </summary>
    [SerializeField, DisplayOnly] public int peopleSatisfaction;

    /// <summary>
    /// 经济
    /// </summary>
    [SerializeField, DisplayOnly] public int economy;

    /// <summary>
    /// 交通
    /// </summary>
    [SerializeField, DisplayOnly] public int transportation;

    /// <summary>
    /// 教育
    /// </summary>
    [SerializeField, DisplayOnly] public int educate;

    /// <summary>
    /// 城市设施
    /// </summary>
    [SerializeField, DisplayOnly] public int cityFacilities;

    /// <summary>
    /// 住房
    /// </summary>
    [SerializeField, DisplayOnly] public int housing;

    /// <summary>
    /// 医疗
    /// </summary>
    [SerializeField, DisplayOnly] public int medical;

    public static ScorePoint operator+(ScorePoint left, ScorePoint right)
    {
        left.economy += right.economy;
        left.educate += right.educate;
        left.housing += right.housing;
        left.medical += right.medical;
        left.transportation += right.transportation;
        left.cityFacilities += right.cityFacilities;
        left.peopleSatisfaction += right.peopleSatisfaction;
        return left;
    }
}