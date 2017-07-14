using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool timeElapsed = false;
	public bool gameWon = false;
	
	private GameModel theGM;
	private InventoryManager theIM;
	private QuestManager theQM;
	private static bool gcExists;
	private int delay = 30;
	
	// Use this for initialization
	void Start () {
		if (!gcExists)
        {
            gcExists = true;
			theGM = FindObjectOfType<GameModel>();
			theIM = FindObjectOfType<InventoryManager>();
			theQM = FindObjectOfType<QuestManager>();
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(theIM == null){
			theIM = FindObjectOfType<InventoryManager>();
		}
		theQM = FindObjectOfType<QuestManager>();
		
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
		
		if(FindObjectOfType<QuestManager>() != null && theQM.finalQuestComplete){
			// if last quest completed, player has won
			if(delay > 0){
				delay--;
			} else {
				Debug.Log("Go to Win Screen");
				Application.LoadLevel("EndStateWin");
				resetGame();
			}
		}
	 
		 if (timeElapsed)
		 {
			 Application.LoadLevel("EndStateLose");
			 resetGame();
		 }
	}
	
	 //If the game controller receives this signal from the timer, it will end the game
	 void timeHasElapsed()
	 {
		 timeElapsed = true;
	 }
	 
	 void playerHasWon()
	 {
		 gameWon = true;
	 }
	 
	 void resetGame(){
		 BroadcastMessage("resetTimer");
		 theGM.deactivateModel();
		 theIM.resetManager();
		 theQM.resetManager();
		 timeElapsed = false;
		 gameWon = false;
	 }
}
