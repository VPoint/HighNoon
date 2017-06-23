using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour {
 	private enum State {NONE, INSPECT, USE, PICKUP, COMBINE}
	private State currState = State.NONE;
	private Item[] combine = new Item[2];
	private Item[] inventory = new Item[3];

	// Use this for initialization
	void Start () {
		// set timer
		// reset score to zero
	}
	
	// Update is called once per frame
	void Update () {
		// decrement timer
		// update score
	}

	public void SetState(int i){
		switch(i){
			case 1:
				currState = State.INSPECT;
			break;
			case 2:
				currState = State.USE;
			break;
			case 3:
				currState = State.PICKUP;
			break;
			case 4:
				currState = State.COMBINE;
			break;
			default:
				currState = State.NONE;
			break;
		}
	}
	
	public void PerformActionOnSelected(Item item){
		if(currState == State.INSPECT){
			item.DisplayDescription();
		} else if(currState == State.USE){
			item.Use();
		} else if(currState == State.PICKUP){
			AddToInventory(item);
		} else if(currState == State.COMBINE){
			if(combine[0] == null){
				combine[0] = item;
				item = null;
			} else {
				combine[1] = item;
			}
			
			if(combine[1] == null && item == null) {
				
				//highlight item and wait for other selection
			} else {
				Combine(combine[0], combine[1]);
			}
		}
	}
	
	private void Combine(Item o1, Item o2){
		if(o1.canBeCombined && o2.canBeCombined){
			
		} else {
			// show dialog with error
		}
	}
	
	private void AddToInventory(Item item){
		
	}
}