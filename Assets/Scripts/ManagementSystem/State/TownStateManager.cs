using System.Collections;
using System.Collections.Generic;
using Module;
using UnityEngine;

public class TownStateManager : BaseSingletonWithMono<TownStateManager>
{
    public bool IsSunny => isSunny;

    public bool IsDayTime => isDayTime;

    [SerializeField] private bool isSunny = true;

    [SerializeField] private bool isDayTime = true;

    public void SetWeather(bool newIsSunny)
    {
        isSunny = newIsSunny;
        // TODO: 完成回调设置
        AudioManager.Instance.SwitchWeatherSound(newIsSunny);
    }

    public void SetDayTime(bool newIsDayTime)
    {
        isDayTime = newIsDayTime;
        // TODO: 完成回调设置
    }
}
