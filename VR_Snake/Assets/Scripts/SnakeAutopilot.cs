using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAutopilot : MonoBehaviour
{
    public enum Rotations
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public static SnakeAutopilot instance;

    private MovementSnake snake;

    private int msInCurrentStep;
    public bool isActive;

    private List<Rotations> pathRotations = new List<Rotations>();
    private List<Vector3> pathNewFoodLocations = new List<Vector3>();
    private int stepInAutopilot = 0;

    public void Start()
    {
        if (instance != null)
        {
            throw new Exception();
        }
        else
        {
            instance = this;
        }

        isActive = false;
        snake = FindObjectsOfType<MovementSnake>()[0];

        addStep(Rotations.NONE, new Vector3(10, 10, 10));
        addStep(Rotations.RIGHT, new Vector3(10, 10, 10));
        addStep(Rotations.NONE, Vector3.back);
        addStep(Rotations.NONE, Vector3.back);
        addStep(Rotations.LEFT, Vector3.back);
        for (int i = 0; i < 6; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.LEFT, Vector3.back);
        addStep(Rotations.NONE, Vector3.back);
        addStep(Rotations.NONE, Vector3.back);
        addStep(Rotations.NONE, new Vector3(15, 15, 15));
        addStep(Rotations.RIGHT, new Vector3(15, 15, 15));
        for (int i = 0; i < 3; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.UP, Vector3.back);
        for (int i = 0; i < 4; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.DOWN, Vector3.back);
        addStep(Rotations.RIGHT, Vector3.back);
        for (int i = 0; i < 5; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.NONE, new Vector3(10, 10, 10));
        addStep(Rotations.RIGHT, new Vector3(10, 10, 10)); //Now we just move back to the inital position
        for (int i = 0; i < 7; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.DOWN, Vector3.back);
        for (int i = 0; i < 4; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.UP, Vector3.back);
        for (int i = 0; i < 6; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.RIGHT, Vector3.back);
        for (int i = 0; i < 5; i++)
        {
            addStep(Rotations.NONE, Vector3.back);
        }
        addStep(Rotations.RIGHT, Vector3.back);
    }

    public void Reset()
    {
        snake.Reset();
        stepInAutopilot = 0;
        snake.UpdatePosition();
    }

    private void addStep(Rotations rotations, Vector3 vector3)
    {
        pathRotations.Add(rotations);
        pathNewFoodLocations.Add(vector3);
    }

    public void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (!snake.hasUpdated)
        {
            return;
        }

        switch (pathRotations[stepInAutopilot])
        {
            case Rotations.NONE:
                break;

            case Rotations.UP:
                snake.rotateUp();
                break;

            case Rotations.DOWN:
                snake.rotateDown();
                break;

            case Rotations.LEFT:
                snake.rotateLeft();
                break;

            case Rotations.RIGHT:
                snake.rotateRight();
                break;

            default:
                break;
        }
        if (pathNewFoodLocations[stepInAutopilot] != Vector3.back)
        {
            UnityEngine.Object.FindObjectOfType<Food>().MoveToLocation(pathNewFoodLocations[stepInAutopilot] + Vector3Extensions.getHalfVector());
        }

        stepInAutopilot++;
        int newStepInAutopilot = stepInAutopilot % pathRotations.Count;
        if (newStepInAutopilot < stepInAutopilot)
        {
            Debug.Log("New autopilot loop");
            snake.ShrinkSnake();
            snake.ShrinkSnake();
        }
        stepInAutopilot = newStepInAutopilot;
    }

    public void activateAutopilot()
    {
        Debug.Log("activating autopilot");
        isActive = true;
        Reset();
        VariableManager.instance.placeRandomFoodActive = false;
    }

    public void deactivateAutopilot()
    {
        Debug.Log("deactivating autopilot");
        isActive = false;
        VariableManager.instance.placeRandomFoodActive = true;
    }

    public void toggleAutopilot()
    {
        if (isActive)
        {
            deactivateAutopilot();
        }
        else
        {
            activateAutopilot();
        }
    }
}
