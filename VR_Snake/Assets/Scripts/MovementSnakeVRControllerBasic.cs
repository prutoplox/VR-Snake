using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA;

public class MovementSnakeVRControllerBasic : MonoBehaviour {
    
    public string[] cnames;
    private float lastUpdate;

    private void Start()
    {
        cnames = Input.GetJoystickNames();
    }

    public void Update()
    {
        if (VariableManager.instance.useVRControllerBasic)
        {
                changeDirection();
        }
    }

    private void changeDirection()
    {
        Debug.Log("Horizontal");
        Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log("Vertical");
        Debug.Log(Input.GetAxis("Vertical"));

        if (!checkMovement())
        {
            return;
        }
 
        if (Input.GetAxis("Vertical") > 0)  
        {
            Debug.Log("+");
            MovementSnake.instance.rotateUp();
            lastUpdate = Time.time;

        }
        else if (Input.GetAxis("Vertical") < -0)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateDown();
            lastUpdate = Time.time;

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("+");
            MovementSnake.instance.rotateRight();
            lastUpdate = Time.time;

        }
        else if (Input.GetAxis("Horizontal") < -0)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateLeft();
            lastUpdate = Time.time;
        }
    }

    private bool checkMovement() {
        float delta = Time.time - lastUpdate;
        if (delta < 0.35)
        {
            return false;
        }
        else {
            return true;
        }
    }
}
