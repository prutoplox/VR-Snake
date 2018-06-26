using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for VR-Gaze to get a better awareness of own position
public class SnakeGaze : MonoBehaviour
{
    private Vector3[] values = new Vector3[2];
    public LineRenderer line;
    public Camera cam;
    private Ray hitInfo;
    private Vector3 headPosition;
    private Quaternion headRotation;
    private Vector3 gazeDirection;


    private Vector3 oldOffset = new Vector3(0, 0, 0);

    void Start()
    {
        line.positionCount = 2;
    }

    void Update()
    {
        transform.rotation = cam.transform.rotation;
        transform.position = cam.transform.position;
        transform.Translate(Vector3.forward * VariableManager.instance.gazeLength);
        headPosition = cam.gameObject.transform.position;
        headPosition.y = headPosition.y - VariableManager.instance.correctGazeYPosition;
        values[0] = headPosition;
        values[1] = transform.position;
        line.SetPositions(values);
        //Get position of the TestCameraParent and move it to the old location to avoid drifting
        Vector3 parentPosition = cam.transform.parent.position - oldOffset;
        //Get position of the TestCamera
        Vector3 camOffset = cam.transform.position;

        oldOffset = camOffset;
        //Substract the postition of the TestCamera relative to the parent to reset it where it should be
        cam.transform.parent.position = parentPosition - camOffset;

    }
}
