using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunButton : MonoBehaviour
{
    public static event Action onLeftClick;
    public static event Action onRightClick;

    public void LeftClick()
    {
        onLeftClick?.Invoke();
    }
    public void RightClick()
    {
        onRightClick?.Invoke();
    }
}
