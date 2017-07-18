using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public bool timeElapsed = false;
	public bool gameWon = false;
	public bool gameEasy = false;
	
	private GameModel theGM;
	private InventoryManager theIM;
	private QuestManager theQM;
	private static bool gcExists;
	
	private float BGMVol = 0.5f;
	private float SFXVol = 0.5f;
	private int delay = 30;
	
	public AudioSource audioGame;
	public AudioSource audioOther;
	public AudioSource gameWin;
	public AudioSource gameLose;
	public float gameTime;
	// Use this for initialization
	void Start () {
		if (!gcExists)
        {
            gcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {		
		if(theIM == null && FindObjectOfType<InventoryManager>() != null){
			theIM = FindObjectOfType<InventoryManager>();
		}
		if(theGM == null && FindObjectOfType<GameModel>() != null){
			theGM = FindObjectOfType<GameModel>();
		}
		if(FindObjectOfType<QuestManager>() != null){
			theQM = FindObjectOfType<QuestManager>();
		}
		
		if(theGM != null && theIM != null){
			if(Application.loadedLevelName == "Landing" && FindObjectOfType<Timer>() != null){
				BroadcastMessage("pauseTimer");
				theGM.deactivateModel();
				theIM.deactivateInventory();
			}
			
			if(Application.loadedLevelName == "Game" ) {
				if(!gameEasy) BroadcastMessage("activateTimer");
				theGM.activateModel();
				theIM.activateInventory();
			}
		} else {
			BroadcastMessage("pauseTimer");
		}
		
		if(Application.loadedLevelName == "Landing" || Application.loadedLevelName == "EndStateLose"
			|| Application.loadedLevelName == "EndStateWin"){
			//change to default background music
			if(!audioOther.isPlaying && !gameLose.isPlaying && !gameWin.isPlaying) audioOther.Play();
			if(audioGame.isPlaying) audioGame.Pause();
		} else if(Application.loadedLevelName == "Game"){
			if(audioOther.isPlaying) audioOther.Stop();
			if(!audioGame.isPlaying) audioGame.Play();
		}
		
		if((FindObjectOfType<QuestManager>() != null && theQM.finalQuestComplete)|| gameWon){
			// if last quest completed, player has won
			if(delay > 0){
				delay--;
			} else {
				Debug.Log("Go to Win Screen");
				gameWin.Play();
				Application.LoadLevel("EndStateWin");
				Timer time = FindObjectOfType<Timer>();
				gameTime= (360 - time.getTime());
				resetGame();
			}
		}
	 
		 if (timeElapsed)
		 {
			 gameLose.Play();
			 Application.LoadLevel("EndStateLose");
			 resetGame();
		 }
	}
	
	public void setVolume(string type, float volume){
		GameObject[] sounds;
        sounds = GameObject.FindGameObjectsWithTag(type);
		if(type == "BGM"){
			BGMVol = volume;
		} else {
			SFXVol = volume;
		}
		foreach (GameObject music in sounds) {
			music.GetComponent<AudioSource>().volume = volume;
		}
	}
	
	public void setGameMode(bool b){
		gameEasy = b;
	}
	
	public bool getGameMode(){
		return gameEasy;
	}
	
	public float getBGMVol(){
		return BGMVol;
	}
	
	public float getSFXVol(){
		return SFXVol;
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
	 
	 public void resetGame(){
		 BroadcastMessage("resetTimer");
		 theGM.deactivateModel();
		 theIM.resetManager();
		 theQM.resetManager();
		 audioGame.Stop();
		 timeElapsed = false;
		 gameWon = false;
	 }
}
