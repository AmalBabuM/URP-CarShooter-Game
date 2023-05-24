using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonHealth : MonoBehaviour,Damage
{
    int heath = 20;
    public void GetDamage(int val)
    {
        heath-=val;
        if (heath <= 0)
        {
            Destroyed();    
        }
    }
    void Destroyed()
    {
       gameObject.SetActive(false);
        Invoke("EnableObject", 2f);
    }

    private void EnableObject()
    {
        gameObject.SetActive(true);
    }



}
