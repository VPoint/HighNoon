﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    public int iBoxNumber;
    public InventoryManager theIM;
    public string iItemName;

    public string collectedItem;

    public GameModel theGM;


    //combination
    public int questNumber;
    public bool canBeCombined;
    public InventoryItem itemToCombine;
    public InventoryItem resultCombine;
    private QuestManager theQM;
    private dialogHolder theDH;
    private DialogueManager theDM;


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
        if (theGM.currState == GameModel.State.COMBINE)
        {
            Debug.Log("1 if loop");
            if (canBeCombined && itemToCombine.canBeCombined && gameObject.activeSelf && itemToCombine.gameObject.activeSelf)
            {
                int iboxNumber2 = itemToCombine.iBoxNumber;

                if (theIM.iBoxes[iBoxNumber].isSelected && itemToCombine.theIM.iBoxes[iboxNumber2].isSelected)
                {
                    Debug.Log("2 if loop");
                    // items for both boxes set to inactive
                    gameObject.SetActive(false);
                    itemToCombine.gameObject.SetActive(false);

                    // both boxes should be unselected and change back to original color
                    theIM.iBoxes[iBoxNumber].isSelected = false;
                    theIM.iBoxes[iBoxNumber].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);

                    itemToCombine.theIM.iBoxes[iboxNumber2].isSelected = false;
                    itemToCombine.theIM.iBoxes[iboxNumber2].GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);

                    if (iBoxNumber < iboxNumber2)
                    {
                        Debug.Log("3 if loop");

                        // box for iboxNumber2 should become inactive
                        itemToCombine.theIM.iBoxes[iboxNumber2].gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("4 if loop");
                        theIM.iBoxes[iBoxNumber].gameObject.SetActive(false);
                    }

                    Debug.Log("5 if loop");
                    // make the result item appreas
                    resultCombine.gameObject.SetActive(true);
                    SetItemsCombined(theQM.quests[questNumber]);
                }

            }
            else
            {
                Debug.Log("else loop");
                Debug.Log("These items cannot be combined together!");
            }
        }

    }

    void OnMouseDown()
    {
        
        

    }

    public void SetItemsCombined(QuestObject qo)
    {
        qo.combined = true;
    }

    //public int FindiBoxNumber(string itemName)
    //{
    //    for (int i = 0; i < theIM.iBoxes.Length; i++)
    //    {
    //        for(int j=0; j<theIM.iBoxes[i].iItems.Length; j++) {
    //            if (theIM.iBoxes[i].iItems[j].iItemName == itemName)
    //                return i;
    //        }
    //    }
    //    return -1;
    //}


}
