using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleCarControls : VeichleControls, ISimpleCarControls
{

    private SimpleCarSimulation Veichle;

    protected override void MyStart()
    {
        Veichle = GetComponent<SimpleCarSimulation>();
    }

    // MyFixedUpdate is called once every fixed framerate frame
    protected override void MyFixedUpdate()
    {
        Accelerate(Input.GetAxis("Accelerate"));
        Steer(Input.GetAxis("Steer"));
    }

    public void Accelerate(float accelValue)
    {
        Veichle.Accelerate(accelValue);
    }

    // steerValue > 0, then steer right
    // steerValue < 0, then steer left
    public void Steer(float steerDirection)
    {
        Veichle.Steer(steerDirection);
    }

}


