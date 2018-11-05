using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Button highscore;
    public Button highscore2;

    // Use this for initialization
    void Start()
    {
        highscore.onClick.AddListener(showHighscore);
        highscore2.onClick.AddListener(showHighscore);
    }

    private void showHighscore()
    {  
        VariableManager.instance.showHighscoreMenu();
    }
}
