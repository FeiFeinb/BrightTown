using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourcesPoint
{
    public int money;
    public int technology;
    public int manPower;

    public static ResourcesPoint operator +(ResourcesPoint left, ResourcesPoint right)
    {
        left.money += right.money;
        left.technology += right.technology;
        left.manPower += right.manPower;
        return left;
    }
}
