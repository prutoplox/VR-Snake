using UnityEngine;
using UnityEngine.UI;

public class OptionHandler : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider powerUpSlider;
    public Slider hardModeSlider;
    public Slider useVrSlider;
    public Slider useGazeSlider;

    public bool isFocusVolume;
    public bool isFocusPowerUp;
    public bool isFocusHardModeOn;
    public bool isFocusUseVr;

    private bool hasValueChanged;

    // Use this for initialization
    void Start()
    {
        hasValueChanged = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        handleHardMode();
        handlePowerUps();
       // handleUseVR();
        handleVolume();

        volumeSlider.value = AudioManager.instance.volume;
        powerUpSlider.value = VariableManager.instance.enablePowerUps ? 1 : 0;
        hardModeSlider.value = VariableManager.instance.enableHardmode ? 1 : 0;
        useVrSlider.value = VariableManager.instance.enableUseVr ? 1 : 0;
        useGazeSlider.value = VariableManager.instance.enableGaze ? 1 : 0;
    }

    public void handleVolume()
    {
        if (hasValueChanged)
        {
            return;
        }

        //if (isFocusVolume)
        if (Input.GetKeyDown(KeyCode.W))

        {
            if (volumeSlider.value == 1)
            {
                volumeSlider.value = 0;
                AudioManager.instance.soundVolume = 0;
                AudioManager.instance.volume = 0;
            }
            else
            {
                volumeSlider.value = 1;
                AudioManager.instance.soundVolume = 1;
                AudioManager.instance.volume = 1;
            }
        }
    }

    public void handlePowerUps()
    {
        if (hasValueChanged)
        {
            return;
        }

        //if (isFocusPowerUp)
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (powerUpSlider.value == 1)
            {
                powerUpSlider.value = 0;
                VariableManager.instance.setPowerUpOff();
            }
            else
            {
                powerUpSlider.value = 1;
                VariableManager.instance.setPowerUpOn();
            }
        }
    }

    public void handleHardMode()
    {
        if (hasValueChanged)
        {
            return;
        }

        // if (isFocusHardModeOn)
        if (Input.GetKeyDown(KeyCode.S))

        {
            if (hardModeSlider.value == 1)
            {
                hardModeSlider.value = 0;
                VariableManager.instance.setHardModeOff();
            }
            else
            {
                hardModeSlider.value = 1;
                VariableManager.instance.setHardModeOn();
            }
        }
    }

  /**  public void handleUseVR()
    {
        if (hasValueChanged)
        {
            return;
        }

        //if (isFocusUseVr)
        if (Input.GetKeyDown(KeyCode.D))

        {
            if (useVrSlider.value == 1)
            {
                useVrSlider.value = 0;
                VariableManager.instance.setUseVrOff();
            }
            else
            {
                useVrSlider.value = 1;
                VariableManager.instance.setUseVrOn();
            }
        }
    }*/
}
