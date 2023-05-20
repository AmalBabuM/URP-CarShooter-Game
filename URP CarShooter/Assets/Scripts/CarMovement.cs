using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    public Joystick joystick;
    float joyStickMinMove = 0.2f;
    [SerializeField] private SpeedSetting carInfo;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;


    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration;
    public float breakingForce;
    public float maxTurnAngle;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnAngle = 0f;

    public Rigidbody rb;
    public float kph;

    private void Start()
    {
        Debug.Log("hi");
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
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        if (joystick.Vertical>= joyStickMinMove || joystick.Vertical<=-joyStickMinMove)
        {
        currentAcceleration = acceleration * joystick.Vertical;
        }
        else
        {
            currentAcceleration= 0f;
        }
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;
        /* Debug.Log(currentAcceleration);*/

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        if (joystick.Horizontal>= joyStickMinMove || joystick.Horizontal<=-joyStickMinMove)
        {
        currentTurnAngle = maxTurnAngle * joystick.Horizontal;
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
}
