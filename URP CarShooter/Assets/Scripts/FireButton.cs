using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
   
}
