using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

    public Camera menucam;
    public Camera maincam;
    public Button start;

    private bool switcher;

    public void Start()
    {
        start.onClick.AddListener(startGame);
        menucam.enabled = true;
        maincam.enabled = false;
        switcher = false;
    }

    public void Update()
    {
        if (switcher == true) {
            initialiseStart();
            switcher = false;
        }
    }

    public void startGame()
    {
        Debug.Log("Start");
        VariableManager.instance.startGame = true;
        switcher = true;
    }

    public void initialiseStart()
    {
        MovementSnake.instance.Reset();
        menucam.enabled = false;
        maincam.enabled = true;
        VariableManager.instance.showMainMenu = false;
    }

}
