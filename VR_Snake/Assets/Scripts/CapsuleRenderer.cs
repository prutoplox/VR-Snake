using System;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRenderer : MonoBehaviour
{
    /*
     *
        line.positionCount = currentPos.Length;
        line.SetPositions(currentPos);
     */
    private Vector3[] positions = null;

    public GameObject initalCapsule;

    private int positionCount = 1;

    List<GameObject> capsules = new List<GameObject>();

    public void Start()
    {
        Debug.Log(initalCapsule);
        initalCapsule.transform.localScale = new Vector3(VariableManager.instance.snakeThicknessX, 1, VariableManager.instance.snakeThicknessZ);
        capsules.Add(initalCapsule);
    }

    public int PositionCount
    {
        get
        {
            return positionCount;
        }

        set
        {
            if (value == positionCount)
            {
                return;
            }

            if (value < 0)
            {
                Debug.LogWarning("Must be at least of positive length");
                return;
            }

            //Debug.Log("setting from " + positionCount + " to " + value);

            // Set the unneeded capsules invisible, there are only positionCount-1 capsules needed to span positionCount positions
            if (value < positionCount)
            {
                for (int i = value - 1; i < capsules.Count; i++)
                {
                    capsules[i].GetComponent<MeshRenderer>().enabled = false;

                    //Debug.Log("\tsetting " + i + " invisible");
                }
            }

            // Set all in range visible and expand if needed
            else if (value > positionCount)
            {
                for (int i = 0; i < Math.Min(value - 1, capsules.Count); i++)
                {
                    capsules[i].GetComponent<MeshRenderer>().enabled = true;

                    //Debug.Log("\tsetting " + i + " visible");
                }

                for (int i = capsules.Count; i < value - 1; i++)
                {
                    //GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    GameObject capsule = Instantiate(initalCapsule);
                    capsules.Add(capsule);
                    capsule.transform.localScale = new Vector3(VariableManager.instance.snakeThicknessX, 1, VariableManager.instance.snakeThicknessZ);

                    //Debug.Log("\tAdding new capsule");
                }
            }

            //Debug.Log("New length is " + value);
            positionCount = value;
        }
    }

    public void SetPositions(Vector3[] positions)
    {
        //Debug.Log("SetPosition:");
        if (positions.Length != positionCount)
        {
            Debug.LogWarning("The length does not match, PositionCount should be set before this method is called!");
            return;
        }

        for (int i = 0; i < positionCount - 1; i++)
        {
            //Debug.Log("Spanning element " + i + " from " + positions[i] + " to " + positions[i + 1]);
            SetPosition(capsules[i], positions[i], positions[i + 1]);
        }
    }

    private void SetPosition(GameObject capsule, Vector3 start, Vector3 end)
    {
        //Debug.Log("setting " + capsule + " from " + start + " to " + end);
        //Move the center to the correct location
        capsule.transform.position = (start + end) / 2;

        //Make it the right length
        Vector3 distance = end - start;
        capsule.transform.localScale = new Vector3(capsule.transform.localScale.x, distance.magnitude * VariableManager.instance.snakeThicknessX, capsule.transform.localScale.z);

        //rotate it into place
        capsule.transform.LookAt(start);
        capsule.transform.Rotate(new Vector3(90, 0, 0));
    }
}
