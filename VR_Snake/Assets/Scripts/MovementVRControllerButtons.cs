using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVRControllerButtons : MonoBehaviour {

    public void Update()
    {
        if (VariableManager.instance.useVRControllerBasicButtons)
        {
            useAction();
        }
    }

    private void useAction()
    {
        if (Input.GetButtonDown(KeyCode.Joystick1Button14.ToString()))
        {
            Debug.Log("action1");
        }
        else if (Input.GetButtonDown(KeyCode.Joystick1Button4.ToString()))
        {
            Debug.Log("action2");
        }
    }
}
