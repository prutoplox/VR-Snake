using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreGameOver : MonoBehaviour {

    public Text scoreText;
    public Text scoreTextS;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (VariableManager.instance.showGameOver){
            scoreText.text = "Score: " + VariableManager.instance.score.ToString("f2");
            scoreTextS.text = "Score: " + VariableManager.instance.score.ToString("f2");
        }
    }
}
