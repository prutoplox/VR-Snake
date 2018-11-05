using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreToText : MonoBehaviour {
    public Text scoreT;
    public Text scoreS;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (VariableManager.instance.showMainMenu)
        {
           scoreT.enabled = false;
           scoreS.enabled = false;
        }
        else
        {
            scoreT.enabled = true;
            scoreS.enabled = true;
            scoreT.text = VariableManager.instance.score.ToString("F2");
            scoreS.text = VariableManager.instance.score.ToString("F2");
        }
	}
}
