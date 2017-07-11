using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour {
 	public enum State {NONE, INSPECT, USE, PICKUP, COMBINE}
	public State currState = State.NONE;
	private Item[] combine = new Item[2];
	private Item[] inventory = new Item[3];


    private InventoryItem[] iItems = new InventoryItem[3];
    public InventoryBox[] iBoxes;
    private static bool gmExists;

    // Use this for initialization
    void Start () {

        if (!gmExists)
        {
            gmExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currState = State.INSPECT;

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
		
		Debug.Log(currState);
	}
	
	public void PerformActionOnSelected(QuestItem qstI, InventoryItem[] invIs ){
		if(currState == State.INSPECT){
			qstI.ShowItemDescription();
		} else if(currState == State.USE){
			//qstI.Use(invIs[0]);
		} else if(currState == State.PICKUP){
			AddToInventory(qstI);
		} else if(currState == State.COMBINE){
			//if(invIs[0] == null){
			//	combine[0] = item;
			//	item = null;
			//} else {
			//	combine[1] = item;
			//}
			
			//if(combine[1] == null && item == null) {
				
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
	
	private void AddToInventory(QuestItem item){
		//bool itemAdded = false;
		//for(int pos = 0; pos < 3; pos++){
		//	if(inventory[pos] == null){
		//		inventory[pos] = item;
		//		itemAdded = true;
		//	}
		//}
		
		//if(!itemAdded) { 
		//	// display inventory full message
		//}
	}
}