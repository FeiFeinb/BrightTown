using System;
using UnityEngine;

[Serializable]
public class ScorePoint
{
    /// <summary>
    /// 民生
    /// </summary>
    public int peopleSatisfaction;

    /// <summary>
    /// 经济
    /// </summary>
    public int economy;

    public static ScorePoint operator+(ScorePoint left, ScorePoint right)
    {
        left.economy += right.economy;
        left.peopleSatisfaction += right.peopleSatisfaction;
        return left;
    }
}