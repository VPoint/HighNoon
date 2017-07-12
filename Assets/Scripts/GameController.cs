using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool timeElapsed = false;
	public bool gameWon = false;
	
	private GameModel theGM;
	private InventoryManager theIM;
	private static bool gcExists;
	
	// Use this for initialization
	void Start () {
		if (!gcExists)
        {
            gcExists = true;
			theGM = FindObjectOfType<GameModel>();
			theIM = FindObjectOfType<InventoryManager>();
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "Landing" && FindObjectOfType<Timer>() != null){
			BroadcastMessage("pauseTimer");
			theGM.deactivateModel();
			theIM.deactivateInventory();
		}
		
		if(Application.loadedLevelName == "Game" ) {
			BroadcastMessage("activateTimer");
			theGM.activateModel();
			theIM.activateInventory();
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
			 BroadcastMessage("resetTimer");
			 timeElapsed = false;
		 }
	}
	
	
	
	 //If the game controller receives this signal from the timer, it will end the game
	 void timeHasElapsed()
	 {
		 timeElapsed = true;
	 }
}
