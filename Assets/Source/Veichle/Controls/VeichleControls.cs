using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VeichleControls : MonoBehaviour {

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
        MyStart();
    }

    // Update is called once per frame
    void Update ()
    {
        if(!gameManager.disableUserInput)
        {
            MyUpdate();
        }
    }

    protected virtual void MyStart(){}

    protected virtual void MyUpdate(){}
}
