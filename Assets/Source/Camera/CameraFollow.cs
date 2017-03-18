using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 Offset;
    public Transform Veichle;

    private Transform myTrasform;

	// Use this for initialization
	void Start ()
    {
        myTrasform = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        myTrasform.position = Veichle.position + Offset;
    }
}
