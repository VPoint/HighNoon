using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour {
 	public enum State {INSPECT, USE, PICKUP, COMBINE}
	public State currState = State.INSPECT;
	
    private static bool gmExists;
	
	private bool active;

    // Use this for initialization
    void Start () {

        if (!gmExists)
        {
            gmExists = true;
			currState = State.INSPECT;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
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
				currState = State.INSPECT;
			break;
		}
		
		Debug.Log(currState);
	}
	
	public void PerformActionOnSelected(QuestItem qstI, InventoryItem[] invIs ){
		if(currState == State.INSPECT){
			qstI.ShowItemDescription();
		} else if(currState == State.USE){
			//;
		} else if(currState == State.PICKUP){
			//AddToInventory(qstI);
		} else if(currState == State.COMBINE){
				
				//highlight item and wait for other selection
            if(invIs[0] == null || invIs[1] == null)
            {
                Debug.Log("Needs to select two items to combined");
            
			}else {
				Combine(invIs[0], invIs[1]);
			}
		}
	}
	
	private void Combine(InventoryItem o1, InventoryItem o2){
		if(o1.canBeCombined && o2.canBeCombined){
			
		} else {
			// show dialog with "These items can not be combined"
			Debug.Log("These two items cannot be combined.");
		}
	}
	
	public void resetModel(){
		gmExists = false;
		Destroy(gameObject);
	}
	 
	public void deactivateModel(){
		if(active){
			gameObject.SetActive(!active);
			currState = State.INSPECT;
			active = false;
		}
	}
	
	public void activateModel(){
		if(!active){
			gameObject.SetActive(!active);
			active = true;
		}
	}

}