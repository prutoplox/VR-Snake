using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject mainmenu;
    public GameObject highscore;
    public GameObject options;
    public GameObject pause;
    public GameObject gameover;

    private void Start()
    {
       
       /* for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Debug.Log(this.gameObject.transform.GetChild(i));
        }*/
    }
    // Update is called once per frame
    void Update () {

        if (VariableManager.instance.showMainMenu == true) {
            mainmenu.GetComponent<Canvas>().enabled = true;
        }
        else {
            mainmenu.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showHighscore == true)
        {
            highscore.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            highscore.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showGameOver == true)
        {
            gameover.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            gameover.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showOptions == true)
        {
            options.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            options.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showPause == true)
        {
            pause.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            pause.GetComponent<Canvas>().enabled = false;
        }
    }
}
