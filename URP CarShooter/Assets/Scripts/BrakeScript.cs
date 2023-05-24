using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BrakeScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;

    public static event Action<bool> isPressedAction;
    
    private void Update()
    {
        if (isPressed)
        {
            isPressedAction?.Invoke(true);
        }
        else
        {
            isPressedAction?.Invoke(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    private void Brake()
    {
        Debug.Log("Hi");
    }
}
