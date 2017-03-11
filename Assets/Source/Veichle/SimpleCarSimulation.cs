using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarSimulation : VeichleSimulation, ISimpleCarControls
{

    public float m_Speed = 12f;                
    public float m_TurnSpeed = 180f;

    private Rigidbody m_Rigidbody;             

    // Use this for initialization
    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Accelerate(float accelValue)
    {
        // Create a vector in the direction the car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * accelValue * m_Speed * Time.deltaTime;
        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    public void Steer(float steerDirection)
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

}
