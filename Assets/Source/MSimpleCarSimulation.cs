using UnityEngine;

public class MSimpleCarSimulation : MonoBehaviour
{

    public float Speed = 12f;
    public float TurnSpeed = 180f;
    public Transform[] FrontWheels;
    public Transform[] RearWheels;
    public Transform Pivot;

    public int TriggerCount = 0;

    public bool engine;
    private Rigidbody m_Rigidbody;
    private int maxWheelsRotation = 20; //degree

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (IsOnTheGround()) EnableEngine();
        else DisableEngine();
        MoveCar(Input.GetAxis("Accelerate"), Input.GetAxis("Steer"));
    }

    public void MoveCar(float accelValue, float steerDirection)
    {
        // Create a vector in the direction the car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * accelValue * Speed * Time.fixedDeltaTime;
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * TurnSpeed * Time.fixedDeltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // If the engine is enabled
        if (engine)
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }

        // Wheel rotation animation
        RotateWheels((accelValue + turn) * Speed, steerDirection * maxWheelsRotation);
    }

    public void MoveCarRigidbody(float accelValue, float steerDirection)
    {
        // Create a vector in the direction the car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * accelValue * Speed * Time.fixedDeltaTime;

        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = steerDirection * TurnSpeed * Time.fixedDeltaTime;

        // If the engine is enabled
        if (engine)
        {
            // Apply this movement to the rigidbody's position.
            m_Rigidbody.AddForce(movement * 1000);
            // Apply this rotation to the rigidbody's rotation.
            if (m_Rigidbody.velocity.x != 0 && m_Rigidbody.velocity.z != 0)
                transform.RotateAround(Pivot.position, Vector3.up, turn);
        }

        // Wheel rotation animation
        RotateWheels((accelValue + turn) * Speed, steerDirection * maxWheelsRotation);
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
    private void OnTriggerEnter(Collider other)
    {
        TriggerCount++;
    }
    private void OnTriggerExit(Collider other)
    {
        TriggerCount--;
    }
    public bool IsOnTheGround()
    {
        return TriggerCount != 0;
    }
    public void EnableEngine()
    {
        engine = true;
    }
    public void DisableEngine()
    {
        engine = false;
    }
}


