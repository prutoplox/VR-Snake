using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA;

public class MovementSnakeVRControllerBasic : MonoBehaviour {
    
    public string[] cnames;

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
        if (Input.GetAxis("Vertical") > 0)  
        {
            Debug.Log("+");
            MovementSnake.instance.rotateUp();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateDown();
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("+");
            MovementSnake.instance.rotateRight();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateLeft();
        }
    }
}
