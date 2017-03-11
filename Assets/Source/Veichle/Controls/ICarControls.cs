using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarControls {

    // Must be called every frame
    void Accelerate(float accelValue);

    // Must be called every frame
    void Steer(float steerDirection);

    void Brake(bool isBraking);

    void Notify(string message);
}
