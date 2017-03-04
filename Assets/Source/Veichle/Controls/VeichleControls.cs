using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VeichleControls : MonoBehaviour {

    protected VeichleSimulation veichle;

    GameManager gameManager;

    void Start()
    {
        veichle = GetComponentInChildren<VeichleSimulation>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(!gameManager.disableUserInput)
        {
            MyUpdate();
        }
    }

    protected virtual void MyUpdate()
    {

    }
}
