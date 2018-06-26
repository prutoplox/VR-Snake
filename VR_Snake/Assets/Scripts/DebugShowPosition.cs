using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Script for creating a camera and snake with smooth movement
public class DebugShowPosition : MonoBehaviour {

    MovementSnake snake;
    public GameObject cam;

	void Start () {
         snake = FindObjectsOfType<MovementSnake>()[0];

         GetPositionsFromSnake();
	}

    Vector3[] oldPositions = null;
    Vector3[] newPositions = null;
    Quaternion oldRotation = Quaternion.identity;
    Quaternion newRotation = Quaternion.identity;

    bool firstLoop = true;

    // Update is called once per frame
    void LateUpdate()
    {
        GetPositionsFromSnake();

        if (firstLoop)
        {
            snake.UpdatePosition();
            GetPositionsFromSnake();
            firstLoop = false;
        }

        if (oldPositions != null)
        {
            float progressMovement = Math.Min(snake.progressInStep * 2, 1);
            float progressRotation = progressMovement;


            Vector3[] currentPos = new Vector3[oldPositions.Length];
            Quaternion currentRotation = Quaternion.Slerp(oldRotation, newRotation, progressRotation);

            for(int i = 0; i < oldPositions.Length; i++)
            {
                currentPos[i] = Vector3.Lerp(oldPositions[i], newPositions[i], progressMovement);
            }

            LineRenderer line = GetComponent<LineRenderer>();
            line.positionCount = currentPos.Length;
            line.SetPositions(currentPos);
            cam.transform.position = currentPos[0];
            cam.transform.rotation = currentRotation;
        }
        else
        {
            Debug.Log("CRAP");
        }

	}

    private void GetPositionsFromSnake()
    {
        if(snake.hasUpdated)
        {
            oldPositions = newPositions;
            oldRotation = newRotation;

            Transform[] trans = new Transform[snake.GetLength() + 1];
            for (int i = 0; i < snake.GetLength(); i++)
            {
                trans[i] = snake.GetStartPositionOf(i);
            }
            trans[snake.GetLength()] = snake.GetEndPositionOf(snake.GetLength() - 1);

            newPositions = Array.ConvertAll(trans, item => item.position);
            newRotation = snake.GetStartPositionOf(0).transform.rotation;
        }
    }
}
