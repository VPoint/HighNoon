using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {
	private Timer time;
	public Text cText;
	private static bool cExists;
	// Use this for initialization
	void Start () {
		time = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(time == null){
			gameObject.SetActive(false);
		} else {
			gameObject.SetActive(true);
			double min = Math.Floor(time.getTime()/60);
			double sec = time.getTime() - min*60;
			
			if(!time.active){
				cText.text = "";
			} else if(sec < 10){
				cText.text = min.ToString() + ":0" + sec.ToString();
			} else {
				cText.text = min.ToString() + ":" + sec.ToString();
			}
			
			//Debug.Log(cText.text);
		}
	}
}
