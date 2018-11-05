using UnityEngine;

public class MovementSnakeVRControllerBasic : MonoBehaviour
{
    private float lastUpdate;

    private void Start()
    {
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
        Debug.Log("LeftHorizontal" + "RightHorizontal");
        Debug.Log(Input.GetAxis("LeftHorizontal") + " | " + Input.GetAxis("LeftHorizontal"));
        Debug.Log("LeftVertical" + "RightVertical");
        Debug.Log(Input.GetAxis("LeftVertical") +" | "+Input.GetAxis("LeftVertical"));

        if (!checkMovement())
        {
            return;
        }

        if (Input.GetAxis("LeftVertical") > 0.3 || Input.GetAxis("RightVertical") > 0.3)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateDown();
            lastUpdate = Time.time;
        }
        else if (Input.GetAxis("LeftVertical") < -0.3 || Input.GetAxis("RightVertical") < -0.3)
        {
            Debug.Log("+");
            MovementSnake.instance.rotateUp();
            lastUpdate = Time.time; 
        }
        else if (Input.GetAxis("LeftHorizontal") > 0.3 || Input.GetAxis("RightHorizontal") > 0.3)
        {
            Debug.Log("+");
            MovementSnake.instance.rotateRight();
            lastUpdate = Time.time;
        }
        else if (Input.GetAxis("LeftHorizontal") < -0.3 || Input.GetAxis("RightHorizontal") < -0.3)
        {
            Debug.Log("-");
            MovementSnake.instance.rotateLeft();
            lastUpdate = Time.time;
        }
    }

    private bool checkMovement()
    {
        float delta = Time.time - lastUpdate;
        if (delta < 0.35)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
