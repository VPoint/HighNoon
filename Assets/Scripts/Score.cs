using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : Text {

	// Use this for initialization
	void Start () {
		//Text cText = FindObjectOfType<Score>();
		GameController gm = FindObjectOfType<GameController>();
		double min = Math.Floor(gm.gameTime/60);
		double sec = (gm.gameTime - min*60);
		
		if(gm.gameEasy){
			text = "You escaped!"
		} else {
			text = "You escaped in:\n" min.ToString() + "min" + sec.ToString() + "sec";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
