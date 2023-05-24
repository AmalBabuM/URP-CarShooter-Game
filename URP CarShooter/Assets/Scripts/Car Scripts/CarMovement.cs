using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    public Joystick joystick;
    float joyStickMinMove = 0.6f;
    [SerializeField] private SpeedSetting carInfo;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;


    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    float acceleration=100;
    public float breakingForce;
    public float maxTurnAngle;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnAngle = 0f;

    public Rigidbody rb;
    public float kph;
    public float maxSpeed = 10f; // Set the maximum speed for the car
    public bool isButtonClicked = false;

    private void Start()
    {
        /*Debug.Log("hi");*/
        BrakeScript.isPressedAction += ApplyBreaks;
        rb = GetComponentInParent<Rigidbody>();
        
        acceleration = carInfo.acceleration;
        breakingForce = carInfo.breakingForce;
        maxTurnAngle = carInfo.maxTurnAngle;

    }

    private void FixedUpdate()
    {
        MoveVehicle();
    }

    private void MoveVehicle()
    {
        if (currentAcceleration <= 0f)
        {
            Debug.Log("boom");
            frontLeft.motorTorque = 10f;
            frontRight.motorTorque = 10f;

        }
        /*frontLeft.motorTorque = 10f;
        frontRight.motorTorque = 10f;*/
        currentAcceleration = rb.velocity.magnitude;
        if (currentAcceleration < maxSpeed)
        {
            /*Debug.Log(currentAcceleration);*/
            // Apply a forward force to the car to make it move forward
            rb.AddForce(transform.forward * maxSpeed, ForceMode.Acceleration);
        }
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        /* Debug.Log(frontLeft.motorTorque);*/

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        if (joystick.Horizontal>= joyStickMinMove || joystick.Horizontal<=-joyStickMinMove)
        {
        currentTurnAngle = maxTurnAngle * joystick.Horizontal*Time.deltaTime*10;
        }
        else
        {
            currentTurnAngle = 0f;
        }
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);


        /*kph = 4 * rb.velocity.magnitude * 3.6f;*/
    }

    private void UpdateWheel(WheelCollider col, Transform tran)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation); // This takes the world position and rotation value of the wheel from the world space and outputs the value

        tran.position = position; //sets the wheel position and rate which we took from above
        tran.rotation = rotation;
    }
    void ApplyBreaks(bool val)
    {   
        if(val)
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }
    }

}
