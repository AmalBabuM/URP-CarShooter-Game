using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject gameOver;
    public static Action<int> HealthSet;
    public static Action<int> HealthReduce;
    Slider slider;
    static int health = 100;


    private void Awake()
    {
        HealthSet += SetHealth;
        HealthReduce += DamageValue;
        slider = GetComponent<Slider>();
        PlayerDamage.OnStart += SetHealth;
    }
    private void OnDisable()
    {
        HealthSet -= SetHealth;
        HealthReduce -= DamageValue; 
        PlayerDamage.OnStart -= SetHealth;
    }
    void Start()
    {
        
    }
    void SetHealth(int val)
    {
        slider.maxValue= val;
        slider.value= val;
    }

    /*public void Damage()
    {
        Debug.Log("HI there");
        health -= 5;
        SetValue(health);


    }*/

    public void DamageValue(int value)
    {
        slider.value -= value;
        if (slider.value <= 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    /*public void LoadHealth(int value)
    {
        health = value;
        SetValue(health);
    }*/
}
