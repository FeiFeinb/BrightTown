using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourcesPoint
{
    [SerializeField, DisplayOnly] public int money;
    [SerializeField, DisplayOnly] public int technology;
    [SerializeField, DisplayOnly] public int manPower;

    public static ResourcesPoint operator +(ResourcesPoint left, ResourcesPoint right)
    {
        left.money += right.money;
        left.technology += right.technology;
        left.manPower += right.manPower;
        return left;
    }
}
