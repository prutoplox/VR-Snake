using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Instance of the AudioManager (static)
    public static AudioManager instance;

    public AudioSource sourceMain;
    public AudioSource sourceSecond;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip snakeEat;
    public AudioClip powerUp;
    public AudioClip gameOverMusic;
    public AudioClip highScoreMusic;
    public AudioClip gameOverCollision;

    public float volume;
    public float soundVolume;

    public bool isRunning;

    // Use this for initialization

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Only one instance allowed");
        }
        sourceMain.GetComponent<AudioSource>();
        sourceSecond.GetComponent<AudioSource>();
        volume = 1.0f;
        soundVolume = 1.0f;
        sourceMain.volume = volume;
        sourceSecond.volume = volume;
        isRunning = false;
    }

    // Volume
    public void setVolumeDown()
    {
        volume -= 0.05f;
    }

    public void setVolumeUp()
    {
        volume += 0.05f;
    }

    public void setVolumeMax()
    {
        volume = 1.0f;
    }

    public void setVolumeMin()
    {
        volume = 0;
    }

    // SoundVolume
    public void setSoundVolumeDown()
    {
        soundVolume -= 0.05f;
    }

    public void setSoundVolumeUp()
    {
        soundVolume += 0.05f;
    }

    public void setSoundVolumeMax()
    {
        soundVolume = 1.0f;
    }

    public void setSoundVolumeMin()
    {
        soundVolume = 0;
    }

    //Music
    public void playMenuMusic()
    {
        sourceMain.volume = volume;
        sourceMain.clip = menuMusic;
        sourceMain.Play();
    }

    public void playGameMusic()
    {
        sourceMain.volume = volume / 2;
        sourceMain.clip = gameMusic;
        sourceMain.Play();
    }

    public void playGamePause()
    {
        sourceMain.volume = volume;
        sourceMain.clip = gameMusic;
        sourceMain.Play();
    }

    public void playHighscoreMusic()
    {
        sourceMain.volume = volume;
        sourceMain.clip = highScoreMusic;
        sourceMain.Play();
    }

    public void playGameOverMusic()
    {
        sourceMain.volume = volume;
        sourceMain.clip = gameOverMusic;
        sourceMain.Play();
    }

    public void playHighScoreSoundAndMusic()
    {
        sourceMain.volume = volume / 2;
        sourceMain.clip = gameMusic;
        sourceSecond.volume = soundVolume;
        sourceSecond.clip = highScoreMusic;
        sourceMain.Play();
        sourceSecond.Play();
    }

    public void playGameOverSoundAndMusic()
    {
        sourceMain.volume = volume / 4;
        sourceMain.clip = gameMusic;
        sourceSecond.volume = soundVolume;
        sourceSecond.clip = gameOverMusic;
        sourceMain.Play();
        sourceSecond.Play();
    }

    //Sounds
    public void playSnakeEat()
    {
        sourceSecond.volume = soundVolume;
        sourceSecond.clip = snakeEat;
        sourceSecond.loop = false;
        sourceSecond.Play();
    }

    public void playPowerUpSound(Vector3 powerUpTransform)
    {
        AudioSource.PlayClipAtPoint(powerUp, powerUpTransform, soundVolume);
    }

    // Update is called once per frame
    void Update()
    {
        sourceMain.volume = volume;
        sourceSecond.volume = volume;
    }
}
