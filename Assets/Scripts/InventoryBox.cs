using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBox : MonoBehaviour
{

    public int boxNumber;

    public InventoryItem[] iItems;
    public InventoryItem iItem;
    public int currentItem;

    public bool isSelected;

    // Use this for initialization
    void Start()
    {


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
        }
    }

    

    public void DesactiveBox()
    {
        iItems[currentItem] = null;
        gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        Debug.Log("Got clicked");
        if (!isSelected) {

            Debug.Log("!isSelected");
            GetComponent<UnityEngine.UI.Image>().color = Color.red;
            isSelected = true;
        }
        else
        {

            Debug.Log("isSelected");
            GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);
            isSelected = false;
        }
    }


}
