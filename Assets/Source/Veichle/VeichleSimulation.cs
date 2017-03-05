using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeichleSimulation : MonoBehaviour, IVeichleControls
{

    public float accelSpeed;
    public float maxBrakeValue;
    public float maxTurnAngle;
    public float turnSpeed;

    public GameObject wheelColliderGo;

    IVeichleControls controller;

    WheelCollider[] wheelsColliders;
    public Transform[] wheelsTransforms;
    public Transform[] anteriorWheels;

    float accel;
    float angle;
    float lastDirection;

    // Use this for initialization
    void Start()
    {
        wheelsColliders = wheelColliderGo.GetComponentsInChildren<WheelCollider>();
    }

    public void Accelerate(float accelValue)
    {
        if (accelValue > 0)
        {
            accel = -accelValue * accelSpeed;
        }
        else if (accelValue < 0)
        {
            accel = -accelValue * accelSpeed * 0.5f;
        }
        else
        {
            accel = 0;
        }

        foreach (WheelCollider wheel in wheelsColliders)
        {
            wheel.motorTorque = accel;
        }

    }

    public void Steer(float steerValue)
    {
        if (steerValue == 0)
        {
            if (angle > 0)
            {
                angle -= Time.deltaTime * maxTurnAngle * turnSpeed;
                angle = Mathf.Max(angle, 0);
            }
            else
            {
                angle += Time.deltaTime * maxTurnAngle * turnSpeed;
                angle = Mathf.Min(angle, 0);
            }

        }
        else
        {
            angle += steerValue * Time.deltaTime * maxTurnAngle * turnSpeed;
            angle = Mathf.Clamp(angle, -maxTurnAngle, maxTurnAngle);
        }

        for (int i = 0; i < 2; i++)
        {
            wheelsColliders[i].steerAngle = angle;
        }

    }

    public void Brake(bool isBraking)
    {
        float currentBrakeValue = 0;

        if (isBraking)
        {
            currentBrakeValue = maxBrakeValue;
        }

        foreach (WheelCollider wheel in wheelsColliders)
        {
            wheel.brakeTorque = currentBrakeValue;
        }
    }

    void Update()
    {
        // Update visual of the models

        // Steer of the wheels
        foreach(Transform wheel in anteriorWheels)
        {
            wheel.localRotation = Quaternion.Euler(0, angle, 0);
        }

        float carVel = Vector3.Magnitude(GetComponentInParent<Rigidbody>().velocity);
        
        if(accel != 0)
        {
            lastDirection = Mathf.Sign(-accel);
        }

        float wheelRotationY = 0;

        if (Mathf.Abs(carVel) > 0.005)
        {
            wheelRotationY = carVel * lastDirection;
        }
        else
        {
            wheelRotationY = accel;
        }

        // Rotate the wheels
        foreach(Transform wheel in wheelsTransforms)
        {
            wheel.localRotation *= Quaternion.Euler(wheelRotationY, 0, 0);
        }
    }

    // Usefull to communicate events to the Controller
    public void Notify(string message)
    {
        throw new NotImplementedException();
    }
}
