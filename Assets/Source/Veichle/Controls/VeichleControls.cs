using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VeichleControls : MonoBehaviour {

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
        MyStart();
    }

    // FixedUpdate is called once every fixed framerate frame
    void FixedUpdate ()
    {
        if(!gameManager.disableUserInput)
        {
            MyFixedUpdate();
        }
    }

    protected virtual void MyStart(){}

    protected virtual void MyFixedUpdate(){}
}
