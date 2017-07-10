using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool timeElapsed = false;
	public bool gameWon = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((Application.loadedLevelName == "EndStateWin" ||
		Application.loadedLevelName == "EndStateLose" ||
		Application.loadedLevelName == "Landing") && FindObjectOfType<Timer>() != null){
			BroadcastMessage("resetTimer");
		}
		if (gameWon)
		 {
			 Application.LoadLevel("EndStateWin");
			 BroadcastMessage("resetTimer");
			 gameWon = false;
		 }
	 
		 if (timeElapsed)
		 {
			 Application.LoadLevel("EndStateLose");
			 timeElapsed = false;
		 }
	}
	
	
	
	 //If the game controller receives this signal from the timer, it will end the game
	 void timeHasElapsed()
	 {
		 timeElapsed = true;
	 }
}
