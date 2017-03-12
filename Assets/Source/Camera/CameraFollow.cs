using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float Offset;
    public Transform Veichle;

    private Transform myTrasform;

	// Use this for initialization
	void Start ()
    {
        myTrasform = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        myTrasform.position = new Vector3(Veichle.position.x - Veichle.forward.x,
                                          myTrasform.position.y,
                                          Veichle.position.z - Veichle.forward.z * Offset);

        myTrasform.eulerAngles = new Vector3(myTrasform.eulerAngles.x,
                                             Veichle.eulerAngles.y,
                                             myTrasform.eulerAngles.z);

    }
}
