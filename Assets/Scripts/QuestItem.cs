using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;

    private QuestManager theQM;
	private dialogHolder theDH;
	private DialogueManager theDM;

    public string itemName;

	public bool needsOtherItemApplied;
	public string otherItemValue;


    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
		theDH = FindObjectOfType<dialogHolder>();
		theDM = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse down method");
		Debug.Log(theQM.itemCollected + " then " + (theQM.itemCollected != otherItemValue).ToString());
		if (needsOtherItemApplied && theQM.itemCollected != otherItemValue){
			ShowItemDescription();
		} else if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            //Debug.Log("Mouse down method activated");
            theQM.itemCollected = itemName;

            gameObject.SetActive(false);

       }

    }
	
	void ShowItemDescription(){
        //Debug.Log("show description!!");
		theDM.dialogLines = theDH.dialogueLines;
        theDM.currentLine = 0;
        theDM.ShowDialog();
	}


}
