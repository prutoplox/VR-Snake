using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        VariableManager.instance.gameTime = 0;
        VariableManager.instance.bonusScore = 100;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         Debug.Log("SCORE" + VariableManager.instance.score.ToString());
         Debug.Log("BONUS SCORE" + VariableManager.instance.bonusScore.ToString());
         Debug.Log("GAMETIME" + VariableManager.instance.gameTime.ToString());
         Debug.Log("ALLTIME" + VariableManager.instance.allTime.ToString());
         Debug.Log("TimeSCORE" + VariableManager.instance.timeScore.ToString());
         */

        if (VariableManager.instance.isRunning)
        {
            calcGameTime();
            calcTimeScore();
            timePunishment();
            calcFinalScore();
        }
        else
        {
            calcFinalScore();
        }
    }

    private static void calcGameTime()
    {
        VariableManager.instance.gameTime = Time.time - VariableManager.instance.startTime;
    }

    private void calcTimeScore()
    {
        VariableManager.instance.timeScore = Time.time - VariableManager.instance.startTime;
    }

    private void adjustScoreForPowerUp(float value)
    {
        VariableManager.instance.bonusScore = VariableManager.instance.bonusScore + (value);
    }

    private void calcFinalScore()
    {
        VariableManager.instance.score = VariableManager.instance.timeScore + VariableManager.instance.bonusScore;
    }

    private void timePunishment()
    {
        if (NearlyEqual((VariableManager.instance.gameTime % 5), 0))
        {
            //adjustScoreForPowerUp(-3);
        }
    }

    public static bool NearlyEqual(float f1, float f2)
    {
        // Equal if they are within 0.00001 of each other
        return Math.Abs(f1 - f2) < 0.018;
    }
}
