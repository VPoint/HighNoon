using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
		
	void play () {
		Application.LoadLevel ("Game");
	}
	
	void goToSettings () {
		Application.LoadLevel ("Settings");
	}
	
	void goToHelp () {
		Application.LoadLevel ("Help");
	}
}
