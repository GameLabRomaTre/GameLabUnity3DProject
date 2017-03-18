using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSimpleCarSimulation : MonoBehaviour
{

    public float Speed = 12f;
    public float TurnSpeed = 180f;
    public Transform[] frontWheels;
    public Transform[] rearWheels;
    private Rigidbody m_Rigidbody;
    private int maxWheelsRotation = 20;//degree
    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveCar(Input.GetAxis("Accelerate"), Input.GetAxis("Steer"));
    }

    public void MoveCar(float accelValue, float steerDirection)
    {
        // Create a vector in the direction the car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * accelValue * Speed * Time.fixedDeltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

        ////Rotation   
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * TurnSpeed * Time.fixedDeltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

        RotateWheels(-20 * accelValue * Speed * Time.fixedDeltaTime, steerDirection * maxWheelsRotation);
    }

    private void RotateWheels(float rotationSpeed, float turn)
    {
        foreach (Transform wheel in frontWheels)
        {
            wheel.Rotate(new Vector3(rotationSpeed, 0, 0));
            wheel.localRotation = Quaternion.Euler(wheel.localRotation.x, wheel.localRotation.y + turn, wheel.localRotation.z);
        }
        foreach (Transform wheel in rearWheels)
        {
            wheel.Rotate(new Vector3(rotationSpeed, 0, 0));
        }
    }

}


