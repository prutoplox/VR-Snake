using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            togglePause();
        }
    }

    private void togglePause()
    {
        if (MovementSnake.instance.isPaused == true)
        {
            stopPause();
        }
        else
        {
            startPause();
        }
    }

    private void startPause()
    {
        MovementSnake.instance.isPaused = true;
        VariableManager.instance.showPauseMenu();
    }

    private void stopPause()
    {
        MovementSnake.instance.isPaused = false;
        VariableManager.instance.showNoMenu();
    }
}
