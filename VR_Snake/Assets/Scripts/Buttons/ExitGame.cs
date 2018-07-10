using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {

    public Button exit;
    public Button exit2;
    // Use this for initialization
    void Start()
    {
        exit.onClick.AddListener(exitGame);
        exit2.onClick.AddListener(exitGame);
    }

    private void exitGame()
    {
        Debug.Log("APP QUIT");
        Application.Quit();
    }
}
