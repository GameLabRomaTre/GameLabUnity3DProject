using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVeichleControls : MonoBehaviour, IVeichleControls {

    VeichleSimulation veichle;
    
	void Start()
    {
        veichle = GetComponentInChildren<VeichleSimulation>();
    }

	// Update is called once per frame
	void Update ()
    {
        Accelerate(Input.GetAxis("Accelerate"));
        Steer(Input.GetAxis("Steer"));
	}

    public void Accelerate(float accelValue)
    {
        veichle.Accelerate(accelValue);
    }

    // steerValue > 0, then steer right
    // steerValue < 0, then steer left
    public void Steer(float steerDirection)
    {
        veichle.Steer(steerDirection);
    }


    public void Notify(string message)
    {
        // Do nothing 
    }
}
