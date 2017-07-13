using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	 public float timeRemaining = 360f;
	 public bool active = true;
	 private static bool tExists;
	 
	 void Start(){
		 if (!tExists)
        {
            tExists = true;
			InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
			 //Debug.Log(timeRemaining + " Seconds remaining!");
		}
	 }
	 
	 void resetTimer(){
		 active = false;
		 timeRemaining = 360f;
	 }
	 
	 void activateTimer(){
		 active = true;
	 }
	 
	 void pauseTimer(){
		 active = false;
	 }
	 
	 public float getTime(){
		 return timeRemaining;
	 }
}
