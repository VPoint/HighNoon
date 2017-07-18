using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{

    public int questNumber;

    private QuestManager theQM;
    private dialogHolder theDH;
    private DialogueManager theDM;
    private GameModel theGM;

    public string itemName;

    public bool needsOtherItemApplied;
    public string otherItemValue;

    //i added
    public int iBoxNumber;
    public int iSlotNumber;
    private InventoryManager theIM;

    public int[] preRq;

    public bool canBePicked;

    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
        theDH = FindObjectOfType<dialogHolder>();
        theDM = FindObjectOfType<DialogueManager>();

        theIM = FindObjectOfType<InventoryManager>();
        theGM = FindObjectOfType<GameModel>();

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
        //Debug.Log(theQM.itemCollected + " then " + (theQM.itemCollected != otherItemValue).ToString());

        if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            Debug.Log("Mouse down method activated");
            theQM.itemCollected = itemName;
            theIM.iItemCollected = itemName;
            Debug.Log("Item collected" + theQM.itemCollected.ToString());
            Debug.Log("The GM curr state " + theGM.currState);

            if (theGM.currState == GameModel.State.PICKUP)
            {
                Debug.Log("(QI)What item do you wanna pick up?");

                if (canBePicked) { 
                    bool allRq = allRqCompleted();
                    Debug.Log("all rq QItem" + allRq);
                    if (allRq == true)
                    {
                        theIM.iBoxes[iBoxNumber].isSelected = false;
                        theIM.iBoxes[iBoxNumber].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);
                        theIM.iBoxes[iBoxNumber].ShowItem(itemName);
                        gameObject.SetActive(false);
                        Destroy(gameObject);

                        SetItemPickedUp(theQM.quests[questNumber]);
                    }
                        
                }
                else
                {
                    theDM.ShowBox("This cannot be picked up.");
                    Debug.Log("This cannot be picked up.");
                }
            }

            if (theGM.currState == GameModel.State.USE)
            {
                Debug.Log("(QI)What item do you wanna use ? ");

                if (theIM.iBoxes[iBoxNumber].isSelected && 
                    theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName == otherItemValue &&
                    theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].gameObject.activeSelf)
                {
                    theDM.ShowBox("And where to apply this item? Choose an item on the screen");
                    Debug.Log("And where to apply this item? Choose an item on the screen");

                    bool allRq = allRqCompleted();
                    Debug.Log("all rq QItem" + allRq);
                    if (allRq == true)
                    {
                        // after use 
                        // The inventory box needs to be inactive, unselected and turns back to original color
                        theIM.iBoxes[iBoxNumber].gameObject.SetActive(false);
                        theIM.iBoxes[iBoxNumber].isSelected = false;
                        theIM.iBoxes[iBoxNumber].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);

                        // the item used in the inventory needs to be inactive
                        theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].gameObject.SetActive(false);

                        // the quest item applied needs to becom inactive
                        gameObject.SetActive(false);
                        //Destroy(gameObject);

                        SetItemUsed(theQM.quests[questNumber]);

                        theDM.ShowBox("You used the item " + theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName);
                        Debug.Log("You used the item " + theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName);

                    }
                }
            }

            if (theGM.currState == GameModel.State.INSPECT)
            {
                theDM.ShowBox("What item do you wanna inspect?");
                Debug.Log("What item do you wanna inspect?");

                ShowItemDescription();
            }

            if(theGM.currState == GameModel.State.COMBINE)
            {
                //theDM.ShowBox("Whats the first item in the inventory do you wanna combine?");
                Debug.Log("(QI)In the INVENTORY, SELECT the items you want to combine.");

            }

        }

    }

    public void fire()
    {
        if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            Debug.Log("Mouse down method activated");
            theQM.itemCollected = itemName;
            theIM.iItemCollected = itemName;
            Debug.Log("Item collected" + theQM.itemCollected.ToString());
            Debug.Log("The GM curr state " + theGM.currState);

            if (theGM.currState == GameModel.State.PICKUP)
            {
                //if (needsOtherItemApplied && theIM.iBoxes[iBoxNumber].iItem.iItemName != otherItemValue) {
                //if (needsOtherItemApplied)
                //{

                //    ShowItemDescription();
                //    Debug.Log("something");
                //}
                //else
                //{
               // theDM.ShowBox("What item do you wanna pick up?");
                Debug.Log("(QI)What item do you wanna pick up?");

                if (canBePicked)
                {
                    bool allRq = allRqCompleted();
                    Debug.Log("all rq QItem" + allRq);
                    if (allRq == true)
                    {
                        theIM.iBoxes[iBoxNumber].isSelected = false;
                        theIM.iBoxes[iBoxNumber].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);
                        theIM.iBoxes[iBoxNumber].ShowItem(itemName);
                        gameObject.SetActive(false);
                        Destroy(gameObject);

                        SetItemPickedUp(theQM.quests[questNumber]);
                    }

                }
                //}
                else
                {
                    theDM.ShowBox("The item you selected is not a pickable item!");
                    Debug.Log("The item you selected is not a pickable item!");
                }
            }

            if (theGM.currState == GameModel.State.USE)
            {
                //theDM.ShowBox("What item do you wanna use?");
                Debug.Log("(QI)What item do you wanna use ? ");

                if (theIM.iBoxes[iBoxNumber].isSelected &&
                    theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName == otherItemValue &&
                    theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].gameObject.activeSelf)
                {
                    theDM.ShowBox("And where to apply this item? Choose an item on the screen");
                    Debug.Log("And where to apply this item? Choose an item on the screen");

                    bool allRq = allRqCompleted();
                    Debug.Log("all rq QItem" + allRq);
                    if (allRq == true)
                    {
                        // after use 
                        // The inventory box needs to be inactive, unselected and turns back to original color
                        theIM.iBoxes[iBoxNumber].gameObject.SetActive(false);
                        theIM.iBoxes[iBoxNumber].isSelected = false;
                        theIM.iBoxes[iBoxNumber].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);

                        // the item used in the inventory needs to be inactive
                        theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].gameObject.SetActive(false);

                        // the quest item applied needs to becom inactive
                        gameObject.SetActive(false);
                        //Destroy(gameObject);

                        SetItemUsed(theQM.quests[questNumber]);

                        theDM.ShowBox("You used the item " + theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName);
                        Debug.Log("You used the item " + theIM.iBoxes[iBoxNumber].iItems[iSlotNumber].iItemName);

                    }
                }
            }

            if (theGM.currState == GameModel.State.INSPECT)
            {
                theDM.ShowBox("What item do you wanna inspect?");
                Debug.Log("What item do you wanna inspect?");

                ShowItemDescription();
            }

            if (theGM.currState == GameModel.State.COMBINE)
            {
                theDM.ShowBox("Whats the first item in the inventory do you wanna combine?");
                Debug.Log("Whats the first item in the inventory do you wanna combine?");

            }

        }
    }

    public void SetItemPickedUp(QuestObject qo)
    {
        qo.pickedUp = true;
    }

    public void SetItemUsed(QuestObject qo)
    {
        qo.used = true;
    }

    public void SetItemSolved(QuestObject qo)
    {
        qo.solved = true;
    }

    public void ShowItemDescription()
    {
        //Debug.Log("show description!!");
        theDM.dialogLines = theDH.dialogueLines;
        theDM.currentLine = 0;
        theDM.ShowDialog();
    }

    public bool allRqCompleted()
    {
        if (questNumber == 0)
        {
            return true;
        }
        else
        {
            for (int i = 0; i < preRq.Length; i++)
            {
                if (theQM.questCompleted[preRq[i]] == false)
                    return false;
            }
            return true;
        }
    }








}
