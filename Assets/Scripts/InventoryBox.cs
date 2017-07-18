using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBox : MonoBehaviour, IPointerDownHandler
{

    public int boxNumber;

    public InventoryItem[] iItems;
    public InventoryItem iItem;
    public int currentItem;

    public bool isSelected;

    private dialogHolder theDH;
    private DialogueManager theDM;
    private GameModel theGM;

    public string[] dialogueLines;

    // Use this for initialization
    void Start()
    {
        theDH = FindObjectOfType<dialogHolder>();
        theDM = FindObjectOfType<DialogueManager>();
        theGM = FindObjectOfType<GameModel>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowItem(string itemName)
    {
        gameObject.SetActive(true);

        for(int i=0; i<iItems.Length; i++) { 
            if(iItems[i].iItemName == itemName)
                iItems[i].gameObject.SetActive(true);
				//iItems[i].GetComponent<UnityEngine.UI.Image>().enabled = true;
				//GetComponent<UnityEngine.UI.Image>().color = Color.blue;
        }
    }

    

    public void DesactiveBox()
    {
        iItems[currentItem] = null;
        gameObject.SetActive(false);
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        


        Debug.Log("Got clicked");
        if (!isSelected) {

            //if (gameObject.activeSelf)
            //{
            //    if (theGM.currState == GameModel.State.PICKUP)
            //    {
            //        theDM.ShowBox("This item is already picked up.");
            //        Debug.Log("This item is already picked up.");

            //    }
            //    else if (theGM.currState == GameModel.State.USE)
            //    {
            //        theDM.ShowBox("Where to apply this item? Choose an item on the screen.");
            //        Debug.Log("Where to apply this item? Choose an item on the screen.");

            //    }
            //    else
            //    {
            //        for (int i = 0; i < iItems.Length; i++)
            //        {
            //            if (iItems[i].gameObject.activeSelf)
            //            {
            //                theDM.ShowBox(dialogueLines[i]);
            //            }
            //        }

            //    }
            //}

            Debug.Log("!isSelected");
            GetComponent<UnityEngine.UI.Image>().color = new Color32(112, 28, 28, 255); ;
            isSelected = true;

            

        }
        else
        {

            Debug.Log("isSelected");
            GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);
            isSelected = false;
        }

        
    }

    //void OnMouseDown()
    //{
    //    if (gameObject.activeSelf)
    //    {
    //        if (theGM.currState == GameModel.State.PICKUP)
    //        {
    //            theDM.ShowBox("This item is already picked up.");
    //            Debug.Log("This item is already picked up.");

    //        }
    //        else if (theGM.currState == GameModel.State.USE)
    //        {
    //            theDM.ShowBox("Where to apply this item? Choose an item on the screen.");
    //            Debug.Log("Where to apply this item? Choose an item on the screen.");

    //        }
    //        else
    //        {
    //            for (int i = 0; i < iItems.Length; i++)
    //            {
    //                if (iItems[i].gameObject.activeSelf)
    //                {
    //                    theDM.ShowBox(dialogueLines[i]);
    //                }
    //            }

    //        }
    //    }
    //}

}