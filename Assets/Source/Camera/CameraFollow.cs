using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float offset;

    public Transform veichle;
    Transform myTrasform;

	// Use this for initialization
	void Start ()
    {
        myTrasform = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        myTrasform.position = new Vector3(veichle.position.x- veichle.forward.x * offset,
                                              myTrasform.position.y,
                                              veichle.position.z - veichle.forward.z * offset);

        myTrasform.eulerAngles = new Vector3(myTrasform.eulerAngles.x,
                                             veichle.eulerAngles.y,
                                             myTrasform.eulerAngles.z);

    }
}
