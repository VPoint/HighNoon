using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	 public float timeRemaining = 60f;
	 public bool active = true;
	 
	 void Start(){
		InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
		 DontDestroyOnLoad(this);
	 }
	 
	 void Update()
	 {
		 if (timeRemaining == 0 && active){
			 SendMessageUpwards("timeHasElapsed");
			 resetTimer();
		 }
	 }
	 
	 void decreaseTimeRemaining(){
		 if(active){
			 timeRemaining --;
			 Debug.Log(timeRemaining + " Seconds remaining!");
		}
	 }
	 
	 void resetTimer(){
		 active = false;
		 timeRemaining = 60f;
	 }
}
