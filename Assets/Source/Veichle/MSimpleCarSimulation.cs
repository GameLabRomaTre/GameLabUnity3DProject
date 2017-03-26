using UnityEngine;

public class MSimpleCarSimulation : MonoBehaviour
{

    public float Speed = 12f;
    public float TurnSpeed = 180f;
    public Transform[] FrontWheels;
    public Transform[] RearWheels;
    public Transform Pivot;

    public bool EnableEngine;

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

        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * TurnSpeed * Time.fixedDeltaTime;

        // If the engine is enabled
        if (EnableEngine)
        {
            // Apply this movement to the rigidbody's position.
            m_Rigidbody.AddForce(movement * 100);
            // Apply this rotation to the rigidbody's rotation.
            if(accelValue != 0)
                transform.RotateAround(Pivot.position, Vector3.up, turn);
        }

        // Wheel rotation animation
        RotateWheels(accelValue != 0 ? (accelValue + turn) * Speed : 0, steerDirection * maxWheelsRotation);
    }

    private void RotateWheels(float rotationSpeed, float turn)
    {
        foreach (Transform wheel in FrontWheels)
        {
            wheel.Rotate(new Vector3(rotationSpeed, 0, 0));
            wheel.localRotation = Quaternion.Euler(wheel.localRotation.x, wheel.localRotation.y + turn, wheel.localRotation.z);
        }
        foreach (Transform wheel in RearWheels)
        {
            wheel.Rotate(new Vector3(rotationSpeed, 0, 0));
        }
    }

    // Checks if the car is on the ground to avoid mid-air acceleration
    void OnTriggerEnter(Collider other)
    {
        EnableEngine = true;
    }
    void OnTriggerExit(Collider other)
    {
        EnableEngine = false;
    }
}


