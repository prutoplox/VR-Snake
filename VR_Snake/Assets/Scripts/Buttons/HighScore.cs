using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Button highscore;
    // Use this for initialization
    void Start () {
        highscore.onClick.AddListener(showHighscore);
    }

    private void showHighscore()
    {
        VariableManager.instance.showGameOver = false;
        VariableManager.instance.showMainMenu = false;
        VariableManager.instance.showOptions = false;
        VariableManager.instance.showPause = false;
        VariableManager.instance.showHighscore = true;
    }
}
