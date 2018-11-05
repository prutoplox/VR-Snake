using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVR : MonoBehaviour
{
    public GameObject[] buttons;
    int selectedButton;
    float scaleFactor = 2f;
    Vector3 originalScale;
    static private int timeout = 0;

    // Use this for initialization
    void Start()
    {
        selectedButton = 0;
        enableButton(selectedButton);
    }

    public void selectMenu()
    {
        disableButton(selectedButton);
        selectedButton = 0;
        enableButton(selectedButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout > 0)
        {
            timeout--;
            return;
        }

        Canvas parentcanvas = GetComponent<Canvas>();
        if (!parentcanvas.enabled)
        {
            return;
        }
        Debug.Log(Input.GetAxis("LeftVertical"));

        if (Input.GetKeyDown(KeyCode.M) || Input.GetAxis("LeftVertical") > 0.3)
        {
            selectNextButton();
            timeout = 6;
        }

        if (Input.GetKeyDown(KeyCode.N) || Input.GetAxis("LeftVertical") < -0.3)
        {
            selectPreviousButton();
            timeout = 6;
        }

        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton14) || Input.GetKeyDown(KeyCode.JoystickButton15))
        {
            timeout = 5;
            selectedMenuFromButton();
        }
    }

    private void selectPreviousButton()
    {
        disableButton(selectedButton);
        selectedButton = ((selectedButton + buttons.Length) - 1) % buttons.Length;
        enableButton(selectedButton);
    }

    private void selectNextButton()
    {
        disableButton(selectedButton);
        selectedButton = (selectedButton + 1) % buttons.Length;
        enableButton(selectedButton);
    }

    private void selectedMenuFromButton()
    {
        Debug.Log("Selecting menu in " + transform.name + " parent is " + transform.parent.name);
        Debug.Log("Canvas enabled is: " + GetComponent<Canvas>().enabled);
        if (buttons[selectedButton].name == "StartGame")
        {
            StartGame.startThisGame = true;
            VariableManager.instance.isRunning = true;

            //VariableManager.instance.startTime = Time.time;
            VariableManager.instance.showNoMenu();
            VariableManager.instance.useGameCam();
            if (SnakeAutopilot.instance.isActive)
            {
                SnakeAutopilot.instance.deactivateAutopilot();
            }
        }
        else if (buttons[selectedButton].name == "MainMenu")
        {
            VariableManager.instance.useMenuCam();
            VariableManager.instance.showMainMenuMenu();
        }
        else if (buttons[selectedButton].name == "Highscore")
        {
            VariableManager.instance.useMenuCam();
            VariableManager.instance.showHighscoresText();
        }
        else if (buttons[selectedButton].name == "Options")
        {
            VariableManager.instance.useMenuCam();
            VariableManager.instance.showOptionsMenu();
        }
        else if (buttons[selectedButton].name == "Resume")
        {
            VariableManager.instance.useMenuCam();
            VariableManager.instance.showNoMenu();
        }
        else if (buttons[selectedButton].name == "Exit")
        {
            Debug.Log("APP QUIT");
            Application.Quit();

            //Not reached once deployed
            return;
        }
        else if (buttons[selectedButton].name == "VolumeOption")
        {
            //VolumeSlider ++
            Slider slider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
            Debug.Log("Volume is " + slider.value);
            if (slider.value == 0f)
            {
                slider.value = 1f;
                AudioManager.instance.setVolumeMax();
                AudioManager.instance.setSoundVolumeMax();
                Debug.Log("Volume set 1");
            }
            else
            {
                slider.value = 0f;
                AudioManager.instance.setVolumeMin();
                AudioManager.instance.setSoundVolumeMin();
                Debug.Log("Volume set 0");
            }
        }
        else if (buttons[selectedButton].name == "PowerUpOption")
        {
            Slider slider = GameObject.Find("PowerUpsSlider").GetComponent<Slider>();
            Debug.Log("powerup is " + slider.value);
            if (slider.value >= 0.5f)
            {
                slider.value = 0f;
                VariableManager.instance.setPowerUpOff();
            }
            else
            {
                slider.value = 1f;
                VariableManager.instance.setPowerUpOn();
            }
        }
        else if (buttons[selectedButton].name == "HardModeOption")
        {
            Slider slider = GameObject.Find("HardModeSlider").GetComponent<Slider>();
            Debug.Log("hard is " + slider.value);
            if (slider.value >= 0.5f)
            {
                slider.value = 0f;
                VariableManager.instance.setHardModeOff();
            }
            else
            {
                slider.value = 1f;
                VariableManager.instance.setHardModeOn();
            }
        }
        else if (buttons[selectedButton].name == "GazeModeOption")
        {
            Slider slider = GameObject.Find("GazeModeSlider").GetComponent<Slider>();
            Debug.Log("Gaze is " + slider.value);
            if (slider.value >= 0.5f)
            {
                slider.value = 0f;
                VariableManager.instance.setGazeModeOff();
            }
            else
            {
                slider.value = 1f;
                VariableManager.instance.setGazeModeOn();
            }
        }
        else if (buttons[selectedButton].name == "VRControlOption")
        {
            Slider slider = GameObject.Find("UseVrSlider").GetComponent<Slider>();
            Debug.Log("vr is " + slider.value);
            if (slider.value >= 0.5f)
            {
                slider.value = 0f;
                VariableManager.instance.setUseVrOff();
            }
            else
            {
                slider.value = 1f;
                VariableManager.instance.setUseVrOn();
            }
        }
        else
        {
            Debug.Log("Menubutton not identified");
            Debug.Log(buttons[selectedButton].name);
            throw new NotImplementedException();
        }
    }

    private void enableButton(int buttonID)
    {
        originalScale = buttons[buttonID].transform.GetChild(0).localScale;
        buttons[buttonID].transform.GetChild(0).localScale = buttons[buttonID].transform.GetChild(0).localScale * scaleFactor;
    }

    private void disableButton(int buttonID)
    {
        buttons[buttonID].transform.GetChild(0).localScale = originalScale;
    }
}
