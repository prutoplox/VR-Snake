using System;
using UnityEngine;

//Script for creating a camera and snake with smooth movement
public class DebugShowPosition : MonoBehaviour
{
    private MovementSnake snake;
    public GameObject head;
    public GameObject tail;
    public GameObject cam;

    void Start()
    {
        snake = FindObjectsOfType<MovementSnake>()[0];

        GetPositionsFromSnake();
    }

    Vector3[] oldPositions = null;
    Vector3[] newPositions = null;
    Quaternion oldRotation = Quaternion.identity;
    Quaternion newRotation = Quaternion.identity;
    Quaternion oldRotationTail = Quaternion.identity;
    Quaternion newRotationTail = Quaternion.identity;

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
            //the following condition is true iff there was a reset
            if (newPositions.Length < oldPositions.Length)
            {
                firstLoop = true;
                return;
            }

            float progressMovement = Math.Min(snake.progressInStep * 2, 1);
            float progressRotation = progressMovement;

            Vector3[] currentPos = new Vector3[oldPositions.Length];
            Quaternion currentRotation = Quaternion.Slerp(oldRotation, newRotation, progressRotation);

            for (int i = 0; i < oldPositions.Length; i++)
            {
                currentPos[i] = Vector3.Lerp(oldPositions[i], newPositions[i], progressMovement);
            }

            /*LineRenderer line = GetComponent<LineRenderer>();
            line.positionCount = currentPos.Length;
            line.SetPositions(currentPos);*/

            //First set the camera at the correct location
            cam.transform.position = currentPos[0];
            if (!VariableManager.instance.useVR360persistent)
            {
                cam.transform.rotation = currentRotation;
            }

            CapsuleRenderer capsule = GetComponent<CapsuleRenderer>();

            //Render the head differently
            head.transform.position = currentPos[0];
            head.transform.rotation = currentRotation;
            head.transform.Translate(Vector3.forward * 0.1f);

            //Render the remaining body of the snake with the simple capsules
            capsule.PositionCount = currentPos.Length;
            capsule.SetPositions(currentPos);

            //Render the tail differently
            int snakeLength = snake.GetLength();

            //GameObject tailLogic = snake.GetSnakePartGameObject(snakeLength - 1);
            tail.transform.position = currentPos[currentPos.Length - 1];
            tail.transform.rotation = Quaternion.Slerp(oldRotationTail, newRotationTail, progressRotation);
            tail.transform.Rotate(new Vector3(-90, 0, 0));
        }
        else
        {
            Debug.Log("Waiting for new data, please hold on...");
        }
    }

    private void GetPositionsFromSnake()
    {
        if (snake.hasUpdated)
        {
            oldPositions = newPositions;
            oldRotation = newRotation;
            oldRotationTail = newRotationTail;

            Transform[] trans = new Transform[snake.GetLength() + 1];
            for (int i = 0; i < snake.GetLength(); i++)
            {
                trans[i] = snake.GetStartPositionOf(i);
            }
            trans[snake.GetLength()] = snake.GetEndPositionOf(snake.GetLength() - 1);

            newPositions = Array.ConvertAll(trans, item => item.position);
            newRotation = snake.GetStartPositionOf(0).transform.rotation;
            newRotationTail = snake.GetSnakePartGameObject(snake.GetLength() - 1).transform.rotation;
        }
    }
}
