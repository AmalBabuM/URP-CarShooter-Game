using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour,Damage
{
    public SpeedSetting CarInfo;
    public static event Action<int> OnStart;
    public void GetDamage(int val)
    {
        SliderScript.HealthReduce?.Invoke(val);
    }

    private void Start()
    {
        SliderScript.HealthSet?.Invoke(CarInfo.maxHP);
        
    }
}
