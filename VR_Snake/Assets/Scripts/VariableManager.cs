using System;
using UnityEngine;
using UnityEngine.UI;

//Script for the VariableManger of SnakeVR
public class VariableManager : MonoBehaviour
{
    //Instance of the VariableManager (static)
    public static VariableManager instance = new VariableManager();

    public HighScoreManager highScoreManager;

    //cams
    public Camera menucam;

    public Camera maincam;

    public bool isDebug;

    //Controller variables
    public bool useVRBasic;

    public bool useVR360persistent;
    public bool useKeyboard;
    public bool useVRAdvanced;
    public bool useExperimental;
    public bool useVRControllerBasic;
    public bool useVRControllerBasicButtons;
    public bool useRotationControl;

    //Win/Lose conditions
    public bool hasWon;

    public bool hasLost;

    //CreateMap
    public Vector3 mapSize;

    public int largerGrid;
    public float largerGridSizeFactor;
    public bool isXAxisLooped;
    public bool isYAxisLooped;
    public bool isZAxisLooped;
    public float scalefactor;

    //MovementSnakeVR
    public float timeBetweenChangeDirection;

    public float sensitivityHorizontal;
    public float sensitivityVertical;

    //Food
    public float foodTimeMin;

    public float foodTimeMax;

    //MovementSnake(Logic)
    public int msPerMovementOfSnake;

    public bool dieOnBodyCollsion;
    public bool dieOnWallCollsion;
    public int initalLength;
    public Vector3 initalPositionHead;
    public Quaternion initalRotation;
    public bool placeRandomFoodActive;

    //Snake 3D Object
    public float snakeThicknessX;

    public float snakeThicknessZ;

    //SnakeGaze
    public float gazeLength;

    public float correctGazeYPosition;

    //User Interface/Menu
    public bool isRunning;

    //
    public bool showMainMenu;
    public bool showHighscore;
    public bool showGameOver;
    public bool showOptions;
    public bool showPause;

    //Score
    public float timeScore;

    public float score;
    public float bonusScore;
    public float startTime;
    public float gameTime;

    //
    public float place1;

    public float place2;
    public float place3;
    public float place4;
    public float place5;

    //Power Ups
    //Shrink
    public float powerUpShrinkTimeMin;
    public float powerUpShrinkTimeMax;

    //Grow
    public float powerUpGrowTimeMin;
    public float powerUpGrowTimeMax;

    //golden Apple
    public float goldenAppleTimeMin;
    public float goldenAppleTimeMax;
    public float goldenApplePointMultiplier;

    //mulit apple
    public float multiAppleTimeMin;

    public float multiAppleTimeMax;
    public float multiAppleExtraApples;

    //row apple
    public float rowAppleTimeMin;

    public float rowAppleTimeMax;
    public float rowAppleExtraApples;

    //Options
    public bool enablePowerUps;

    public bool enableHardmode;
    public bool enableGaze;
    public bool enableUseVr;
    //Gaze
    public LineRenderer gaze;

    //Scores

    //Scores
    public Text placeT1;

    public Text placeT2;
    public Text placeT3;
    public Text placeT4;
    public Text placeT5;

    //shadow text
    public Text place1shadow;

    public Text place2shadow;
    public Text place3shadow;
    public Text place4shadow;
    public Text place5shadow;
    /*
     * Force that the correct values are accessible each and every time
     * and not depending on the order when the start() was called.
     */

    public void Awake()
    {
        getHighScores();
        instance = this;
        isDebug = true;
        useExperimental = false;
        useKeyboard = true;
        useVRAdvanced = false;
        useVRBasic = false;
        useVR360persistent = false;
        useVRControllerBasic = true;
        useVRControllerBasicButtons = false;
        useRotationControl = false;

        timeBetweenChangeDirection = 2.0f;
        sensitivityHorizontal = 0.3f;
        sensitivityVertical = 0.1f;
        correctGazeYPosition = 0.25f;
        gazeLength = 30f;

        foodTimeMin = 1;
        foodTimeMax = 2;

        mapSize = new Vector3(20, 20, 20);
        largerGrid = 5;
        largerGridSizeFactor = 5f;
        isXAxisLooped = false;
        isYAxisLooped = false;
        isZAxisLooped = false;

        hasWon = false;
        hasLost = false;
        msPerMovementOfSnake = 900;
        dieOnBodyCollsion = true;
        dieOnWallCollsion = true;
        initalLength = 2;
        initalPositionHead = new Vector3(mapSize.x / 2, mapSize.y / 2, 0);
        initalRotation = Quaternion.Euler(Vector3.zero);
        placeRandomFoodActive = true;

        snakeThicknessX = 0.6f;
        snakeThicknessZ = snakeThicknessX;

        isRunning = false;
        showMainMenu = true;
        showHighscore = false;
        showGameOver = false;
        showOptions = false;
        showPause = false;

        //Shrink
        powerUpShrinkTimeMin = 40;
        powerUpShrinkTimeMax = 45;

        //Grow
        powerUpGrowTimeMin = 50;
        powerUpGrowTimeMax = 60;

        //golden Apple
        goldenAppleTimeMin = 20;
        goldenAppleTimeMax = 30;
        goldenApplePointMultiplier = 10;

        //mulit apple
        multiAppleTimeMin = 2;
        multiAppleTimeMax = 6;
        multiAppleExtraApples = 5;

        //row apple
        rowAppleTimeMin = 40;
        rowAppleTimeMax = 120;
        rowAppleExtraApples = 3;

        //Options
        enablePowerUps = true;
        enableHardmode = false;
        enableUseVr = true;
        enableGaze = true;
    }

    public void showNoMenu()
    {
        showGameOver = false;
        showMainMenu = false;
        showPause = false;
        showHighscore = false;
        showOptions = false;
    }

    public void showGameOverMenu()
    {
        showMainMenu = false;
        showPause = false;
        showHighscore = false;
        showOptions = false;
        showGameOver = true;
    }

    public void showMainMenuMenu()
    {
        showGameOver = false;
        showPause = false;
        showHighscore = false;
        showOptions = false;
        showMainMenu = true;
    }

    public void showPauseMenu()
    {
        showGameOver = false;
        showMainMenu = false;
        showPause = true;
        showHighscore = false;
        showOptions = false;
    }

    public void showHighscoreMenu()
    {
        showHighscore = true;
        showGameOver = false;
        showMainMenu = false;
        showPause = false;
        showOptions = false;
    }

    public void showOptionsMenu()
    {
        showGameOver = false;
        showMainMenu = false;
        showPause = false;
        showHighscore = false;
        showOptions = true;
    }

    public void useGameCam()
    {
        SnakeAutopilot.instance.deactivateAutopilot();
        menucam.enabled = false;
        maincam.enabled = true;
        if (SnakeAutopilot.instance.isActive)
        {
            SnakeAutopilot.instance.deactivateAutopilot();
        }
    }

    public void useMenuCam()
    {
        SnakeAutopilot.instance.activateAutopilot();
        maincam.enabled = false;
        menucam.enabled = true;
        if (SnakeAutopilot.instance != null)
        {
            if (!SnakeAutopilot.instance.isActive)
            {
                SnakeAutopilot.instance.activateAutopilot();
            }
        }
    }

    public void setUseVrOff()
    {
        enableUseVr = false;
        VariableManager.instance.useVR360persistent = false;
        VariableManager.instance.useKeyboard = true;
        VariableManager.instance.useVRControllerBasic = true;
        VariableManager.instance.useRotationControl = true;
        VariableManager.instance.useVRControllerBasicButtons = true;
        
    }

    public void setUseVrOn()
    {
        enableUseVr = true;
        VariableManager.instance.useVR360persistent = true;
        VariableManager.instance.useKeyboard = true;
        VariableManager.instance.useVRControllerBasic = true;
        VariableManager.instance.useRotationControl = true;
        VariableManager.instance.useVRControllerBasicButtons = true;
    }

    public void setHardModeOff()
    {
        enableHardmode = false;
    }

    public void setHardModeOn()
    {
        enableHardmode = true;
    }

    public void setGazeModeOff()
    {
        gaze.enabled = false;
        enableGaze = false;
    }

    public void setGazeModeOn()
    {
        gaze.enabled = true;
        enableGaze = true;
    }

    public void setPowerUpOn()
    {
        enablePowerUps = true;
        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpGrow>())
        {
            item.ScheduleRespawn();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpGoldenApple>())
        {
            item.ScheduleRespawn();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpShrink>())
        {
            item.ScheduleRespawn();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpMultiApple>())
        {
            item.ScheduleRespawn();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpRowApple>())
        {
            item.ScheduleRespawn();
        }
    }

    public void setPowerUpOff()
    {
        enablePowerUps = false;

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpGrow>())
        {
            item.hideObject();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpGoldenApple>())
        {
            item.hideObject();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpShrink>())
        {
            item.hideObject();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpMultiApple>())
        {
            item.hideObject();
        }

        foreach (var item in UnityEngine.Object.FindObjectsOfType<PowerUpRowApple>())
        {
            item.hideObject();
        }
    }

    public void resetPowerUp()
    {
        setPowerUpOff();
        setPowerUpOn();
    }

    public void getHighScores()
    {
        if (PlayerPrefs.HasKey("1"))
        {
            place1 = PlayerPrefs.GetFloat("1");
        }
        if (PlayerPrefs.HasKey("2"))
        {
            place2 = PlayerPrefs.GetFloat("2");
        }
        if (PlayerPrefs.HasKey("3"))
        {
            place3 = PlayerPrefs.GetFloat("3");
        }
        if (PlayerPrefs.HasKey("4"))
        {
            place4 = PlayerPrefs.GetFloat("4");
        }
        if (PlayerPrefs.HasKey("5"))
        {
            place5 = PlayerPrefs.GetFloat("5");
        }
    }

    //public Methods here
    public static void doSth()
    {
        Debug.Log("do sth");
    }

    public void eatPoints()
    {
        bonusScore += 100;
    }

    public void showHighscoresText()
    {
        setHighscoreToTextFields();
        VariableManager.instance.showHighscoreMenu();
    }

    public void setHighscoreToTextFields()
    {
        string[] scores = VariableManager.instance.highScoreManager.getTopFiveHighscoreAsArray();
        placeT1.text = "1: \t" + scores[0];
        placeT2.text = "2: \t" + scores[1];
        placeT3.text = "3: \t" + scores[2];
        placeT4.text = "4: \t" + scores[3];
        placeT5.text = "5: \t" + scores[4];

        place1shadow.text = "1: \t" + scores[0];
        place2shadow.text = "2: \t" + scores[1];
        place3shadow.text = "3: \t" + scores[2];
        place4shadow.text = "4: \t" + scores[3];
        place5shadow.text = "5: \t" + scores[4];
        /**}
        catch (Exception)
        {
            Debug.Log("VariableManager not init");
        }**/
    }
}
