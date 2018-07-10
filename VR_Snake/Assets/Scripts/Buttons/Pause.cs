using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            if (MovementSnake.instance.isPaused == true)
            {
                stopPause();
            }
            else
            {
                startPause();
            }
        }
    }

    private void startPause()
    {
        MovementSnake.instance.isPaused = true;
        VariableManager.instance.showGameOver = false;
        VariableManager.instance.showMainMenu = false;
        VariableManager.instance.showHighscore = false;
        VariableManager.instance.showOptions = false;
        VariableManager.instance.showPause = true;
    }

    private void stopPause()
    {
        MovementSnake.instance.isPaused = false;
        VariableManager.instance.showGameOver = false;
        VariableManager.instance.showMainMenu = false;
        VariableManager.instance.showHighscore = false;
        VariableManager.instance.showOptions = false;
        VariableManager.instance.showPause = false;
    }
}
