using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSimpleCarSimulation : MonoBehaviour
{

    public float Speed = 12f;
    public float TurnSpeed = 180f;
    public Transform[] wheels;

    private Rigidbody m_Rigidbody;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Accelerate(Input.GetAxis("Accelerate"));
        Steer(Input.GetAxis("Steer"));
    }

    public void Accelerate(float accelValue)
    {
        // Create a vector in the direction the car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * accelValue * Speed * Time.fixedDeltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

        RotateWheels(-20 * accelValue * Speed * Time.deltaTime);
    }

    public void Steer(float steerDirection)
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    private void RotateWheels(float force)
    {
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(new Vector3(force, 0, 0));
        }
    }

}


