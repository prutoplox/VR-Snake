using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for Controlling the Snake with Keyboard
public class MovementKeyboard : MonoBehaviour {

    void Update()
    {
        if (VariableManager.instance.useKeyboard)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Debug.Log("up");
                MovementSnake.instance.rotateUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Debug.Log("down");
                MovementSnake.instance.rotateDown();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //Debug.Log("left");
                MovementSnake.instance.rotateLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Debug.Log("right");
                MovementSnake.instance.rotateRight();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                //Debug.Log("right");
                MovementSnake.instance.rotateViewClockwise();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("right");
                MovementSnake.instance.rotateViewCounterClockwise();
            }
        }
    }
}
