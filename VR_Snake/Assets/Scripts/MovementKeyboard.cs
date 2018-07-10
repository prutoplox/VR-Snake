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
            else if (Input.GetKeyDown(KeyCode.Q) && VariableManager.instance.useRotationControl)
            {
                //Debug.Log("right");
                MovementSnake.instance.rotateViewClockwise();
            }
            else if (Input.GetKeyDown(KeyCode.E) && VariableManager.instance.useRotationControl)
            {
                //Debug.Log("right");
                MovementSnake.instance.rotateViewCounterClockwise();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                //Debug.Log("reset");
                MovementSnake.instance.Reset();
            }
            else if (Input.GetKeyDown(KeyCode.J) && VariableManager.instance.isDebug)
            {
                Debug.Log("grow");
                MovementSnake.instance.GrowSnake();
            }
            else if (Input.GetKeyDown(KeyCode.K) && VariableManager.instance.isDebug)
            {
                Debug.Log("shrink");
                MovementSnake.instance.ShrinkSnake();
            }
            else if (Input.GetKeyDown(KeyCode.L) && VariableManager.instance.isDebug)
            {
                Debug.Log("toggle Autopilot");
                SnakeAutopilot.instance.toggleAutopilot();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("toggle pause");
                MovementSnake.instance.togglePause();
            }
        }
    }
}
