using UnityEngine;

//CameraFollow Script for player to focus the snake all time
public class CameraFollow : MonoBehaviour
{
    public GameObject snake;

    void LateUpdate()
    {
        transform.LookAt(snake.transform);
    }
}