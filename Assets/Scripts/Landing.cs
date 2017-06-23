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
	
		
	public void Play () {
		Application.LoadLevel ("Game");
	}
	
	public void GoToSettings () {
		Application.LoadLevel ("Settings");
	}
	
	public void GoToHelp () {
		Application.LoadLevel ("Help");
	}
}
