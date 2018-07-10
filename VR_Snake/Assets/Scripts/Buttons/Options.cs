using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Button options;
    public Button options1;
    // Use this for initialization
    void Start()
    {
        options.onClick.AddListener(showOptions);
        options1.onClick.AddListener(showOptions);
    }

    private void showOptions()
    {
        VariableManager.instance.showGameOver = false;
        VariableManager.instance.showMainMenu = false;
        VariableManager.instance.showPause = false;
        VariableManager.instance.showHighscore = false;
        VariableManager.instance.showOptions = true;
    }
}
