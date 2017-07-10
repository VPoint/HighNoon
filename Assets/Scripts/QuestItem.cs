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
        //if (!theQM.questCompleted[questNumber])
        //   gameObject.SetActive(true);
        //else
        //    gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse down method");
		Debug.Log("Quest"+ questNumber + "completed?? " + !theQM.questCompleted[questNumber]);
		Debug.Log(theQM.itemEquipped + " then " + needsOtherItemApplied + " and " + (theQM.itemEquipped == otherItemValue));
		if (!theQM.questCompleted[questNumber]){
            Debug.Log("Mouse down method activated");

            if (needsOtherItemApplied && !(theQM.itemEquipped == otherItemValue)){
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
        //es added
        Debug.Log("show description!!");
		//theDM.dialogLines = theDH.dialogueLines;
        //theDM.currentLine = 0;
        //theDM.ShowDialog();
	}


}
