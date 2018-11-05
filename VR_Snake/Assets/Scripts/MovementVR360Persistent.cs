using UnityEngine;
using UnityEngine.XR;

//Script for alternative movement
public class MovementVR360Persistent : MonoBehaviour
{

    void Update()
    {
        if (VariableManager.instance.useVR360persistent)
        {
           // Debug.Log((InputTracking.GetLocalRotation(XRNode.Head)).ToString());
            changeDirection();
        }
    }

    private void changeDirection()
    {
        Quaternion rotation = InputTracking.GetLocalRotation(XRNode.Head);
        Debug.Log("EulerAngles" + rotation.eulerAngles);
        float roundedX = roundToNextAxis(rotation.eulerAngles.x);
        float roundedY = roundToNextAxis(rotation.eulerAngles.y);
        float roundedZ = roundToNextAxis(rotation.eulerAngles.z);
        //Debug.Log("Rounded X" +roundedX);
       // Debug.Log("Rounded Y" + roundedY);
       // Debug.Log("Rounded Z" + roundedZ);

        Vector3 newRotation = new Vector3(roundedX, roundedY, roundedZ);
        Debug.Log("Rotating to...");
        // Debug.Log(newRotation);
        MovementSnake.instance.setRotation(newRotation);
    }

    public static float roundToNextAxis(float p)
    {
        p = (p % 360 + 360) % 360; //Make sure the value is between 0 and 360
        float pOffset45 = p + 45;
        float tmp2 = pOffset45 / 90;
        float tmp3 = Mathf.Floor(tmp2);
        float returnValue = (tmp3 * 90) % 360;
        return returnValue;
    }
}
