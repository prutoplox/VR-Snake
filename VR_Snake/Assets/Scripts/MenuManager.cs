using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject highscore;
    public GameObject options;
    public GameObject pause;
    public GameObject gameover;

    private void Start()
    {
        Debug.Log("MenuManager Init");
    }

    // Update is called once per frame
    void Update()
    {
        if (VariableManager.instance.showMainMenu == true)
        {
            SnakeAutopilot.instance.activateAutopilot();
            mainmenu.GetComponent<Canvas>().enabled = true;

            if (AudioManager.instance.sourceMain.clip != AudioManager.instance.menuMusic)
            {
                AudioManager.instance.playMenuMusic();
            }
        }
        else
        {
            mainmenu.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showHighscore == true)
        {
            highscore.GetComponent<Canvas>().enabled = true;

            if (AudioManager.instance.sourceMain.clip != AudioManager.instance.highScoreMusic)
            {
                AudioManager.instance.playHighscoreMusic();
            }
        }
        else
        {
            highscore.GetComponent<Canvas>().enabled = false;
        }

        if (VariableManager.instance.showGameOver == true)
        {
            gameover.GetComponent<Canvas>().enabled = true;

            if (AudioManager.instance.sourceMain.clip != AudioManager.instance.gameOverMusic)
            {
                AudioManager.instance.playGameOverMusic();
            }
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
