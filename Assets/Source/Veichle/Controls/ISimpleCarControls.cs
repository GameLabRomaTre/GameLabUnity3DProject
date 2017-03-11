using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISimpleCarControls {

    void Accelerate(float accelValue);
    void Steer(float steerDirection);

}
