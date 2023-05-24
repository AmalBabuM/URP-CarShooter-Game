using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpeed : MonoBehaviour
{
    public float maxSpeed = 10f; // Set the maximum speed for the car

    private Rigidbody rb;
    bool brake = false;

    private void Start()
    {
        BrakeScript.isPressedAction += ApplyBreaks;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = rb.velocity.magnitude;

        // Check if the car's current speed is less than the maximum speed
        if (currentSpeed < maxSpeed && !brake)
        {
            // Apply a forward force to the car to make it move forward
            rb.AddForce(transform.forward * maxSpeed, ForceMode.Acceleration);
        }
    }
    void ApplyBreaks(bool val)
    {
        brake = val;
    }
}
