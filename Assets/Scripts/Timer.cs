using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	 public float timeRemaining = 60f;
	 
	 void Start(){
		 InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
		 DontDestroyOnLoad(this);
	 }
	 
	 void Update()
	 {
		 if (timeRemaining == 0){
			 SendMessageUpwards("timeHasElapsed");
			 destroyTimer();
		 }
	 
		 Debug.Log(timeRemaining + " Seconds remaining!");
	 }
	 
	 void decreaseTimeRemaining(){
		 timeRemaining --;
	 }
	 
	 void destroyTimer(){
		 Destroy(this);
	 }
}
