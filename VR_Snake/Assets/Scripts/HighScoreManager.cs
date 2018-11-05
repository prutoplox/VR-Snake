using System;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private List<float> scores;

    public void Update()
    {
    }

    public void Start()
    {
        Debug.Log("HighScoreManager Start");
        VariableManager.instance.highScoreManager = this;
    }

    public void setHighScore(float score)
    {
        bool gotIntoTheScore = false;
        if (score > PlayerPrefs.GetFloat("hs_1"))
        {
            float temp = PlayerPrefs.GetFloat("hs_1");
            PlayerPrefs.SetFloat("hs_1", score);
            score = temp;
        }
        if (score >= PlayerPrefs.GetFloat("hs_2"))
        {
            float temp = PlayerPrefs.GetFloat("hs_2");
            PlayerPrefs.SetFloat("hs_2", score);
            score = temp;
        }
        if (score >= PlayerPrefs.GetFloat("hs_3"))
        {
            float temp = PlayerPrefs.GetFloat("hs_3");
            PlayerPrefs.SetFloat("hs_3", score);
            score = temp;
        }
        if (score >= PlayerPrefs.GetFloat("hs_4"))
        {
            float temp = PlayerPrefs.GetFloat("hs_4");
            PlayerPrefs.SetFloat("hs_4", score);
            score = temp;
        }
        if (score >= PlayerPrefs.GetFloat("hs_5"))
        {
            float temp = PlayerPrefs.GetFloat("hs_5");
            PlayerPrefs.SetFloat("hs_5", score);
            score = temp;
            gotIntoTheScore = true;
        }

        if (gotIntoTheScore)
        {
            Debug.Log("NEW HIGHSCORE WOWOWOWOWOOW " + score);
        }
    }

    public string getHighscoreAsString(string place)
    {
        if (PlayerPrefs.HasKey(place))
        {
            return String.Format("{0,7:0.0}", PlayerPrefs.GetFloat(place));
        }
        else
        {
            return "000";
        }
    }

    public string[] getTopFiveHighscoreAsArray()
    {
        return new string[] { getHighscoreAsString("hs_1"), getHighscoreAsString("hs_2"), getHighscoreAsString("hs_3"), getHighscoreAsString("hs_4"), getHighscoreAsString("hs_5") };
    }
}