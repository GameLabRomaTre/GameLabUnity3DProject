using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleCarControls : VeichleControls, ISimpleCarControls
{

    SimpleCarSimulation veichle;

    protected override void MyStart()
    {
        veichle = GetComponent<SimpleCarSimulation>();
    }

    // MyUpdate is called once per frame
    protected override void MyUpdate()
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

}


