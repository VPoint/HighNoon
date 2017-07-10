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

    //i added
    public int iBoxNumber;
    private InventoryManager theIM;

    //private static bool qItemExists;


    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
		theDH = FindObjectOfType<dialogHolder>();
		theDM = FindObjectOfType<DialogueManager>();

        theIM = FindObjectOfType<InventoryManager>();

        

        //if (!qItemExists)
        //{
        //    qItemExists = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (!theQM.questCompleted[questNumber])
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse down method");
		Debug.Log(theQM.itemCollected + " then " + (theQM.itemCollected != otherItemValue).ToString());
		if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            //Debug.Log("Mouse down method activated");
            theQM.itemCollected = itemName;
            theIM.iItemCollected = itemName;

            if (needsOtherItemApplied && theQM.itemCollected != otherItemValue)
            {
                ShowItemDescription();
            }
            else
            {

                theIM.iBoxes[iBoxNumber].ShowItem(itemName);
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }

       }

    }
	
	void ShowItemDescription(){
        //es added
        //Debug.Log("show description!!");
		theDM.dialogLines = theDH.dialogueLines;
        theDM.currentLine = 0;
        theDM.ShowDialog();
	}


}
