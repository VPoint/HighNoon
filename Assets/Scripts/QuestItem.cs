using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;

    private QuestManager theQM;
	private DialogHolder theDH;
	private DialogueManager theDM;

    public string itemName;

	public bool needsOtherItemApplied;
	public string otherItemValue;
	
	public int iBoxNumber;
    private InventoryManager theIM;


    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
		theDH = FindObjectOfType<DialogHolder>();
		theDM = FindObjectOfType<DialogueManager>();
		
		 theIM = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse down method");
		Debug.Log(theQM.itemCollected + " then " + (theQM.itemCollected != otherItemValue).ToString());
		if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf){
			
			if(needsOtherItemApplied && theQM.itemCollected != otherItemValue){
				ShowItemDescription();
			} else {
				Debug.Log("Entered in the QuestItem Else");
				// THIS NEEDS TO BE CONDITIONAL ON WHETHER WE ACTUALLY COLLECT THIS ITEM
				if(itemName == "Spoon"){
					Debug.Log(itemName + " should join the inventory");
					theIM.iBoxes[iBoxNumber].ShowItem(itemName);
					theIM.iItemCollected = itemName;
					gameObject.SetActive(false);
				}else {
					Debug.Log(itemName + " should disappear or something");
					Destroy(gameObject);
				}
				
				theQM.itemCollected = itemName;

		   }
		   
		}

    }
	
	void ShowItemDescription(){
        //Debug.Log("show description!!");
		theDM.dialogLines = theDH.dialogueLines;
        theDM.currentLine = 0;
        theDM.ShowDialog();
	}


}
