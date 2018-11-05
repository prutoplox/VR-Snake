using UnityEngine;
using UnityEngine.XR;

//Script for controlling the snake with the VR-Headset's position/rotation
public class MovementSnakeVR : MonoBehaviour
{
    float timeLeft = VariableManager.instance.timeBetweenChangeDirection;

    public void Update()
    {
        if (VariableManager.instance.useVRBasic)
        {
            //Debug.Log((InputTracking.GetLocalRotation(XRNode.Head)).ToString());
            if (timeLeft <= 0)
            {
                changeDirection();
                timeLeft = VariableManager.instance.timeBetweenChangeDirection;
            }
            timeLeft -= Time.deltaTime;
        }
    }

    private void changeDirection()
    {
        if (InputTracking.GetLocalRotation(XRNode.Head).x > VariableManager.instance.sensitivityVertical)
        {
            MovementSnake.instance.rotateDown();
        }
        else if (InputTracking.GetLocalRotation(XRNode.Head).x < -VariableManager.instance.sensitivityVertical)
        {
            MovementSnake.instance.rotateUp();
        }
        if (InputTracking.GetLocalRotation(XRNode.Head).y > VariableManager.instance.sensitivityHorizontal)
        {
            MovementSnake.instance.rotateRight();
        }
        else if (InputTracking.GetLocalRotation(XRNode.Head).y < -VariableManager.instance.sensitivityHorizontal)
        {
            MovementSnake.instance.rotateLeft();
        }
    }
}
