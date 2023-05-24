using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormRotator : MonoBehaviour
{
    public float rotSpeed;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }
}
