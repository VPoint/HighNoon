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

    //private static bool iBoxExists;






    // Use this for initialization
    void Start()
    {

        //if (!iBoxExists)
        //{
        //    iBoxExists = true;
        //    //DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    if (iItems[currentItem] != null)
        //    {
        //        gameObject.SetActive(true);

        //        //iItems[currentItem].gameObject.SetActive(true);
        //        iItem.gameObject.SetActive(true);
        //    }
        //}

        //if (iItems[currentItem] != null)
        //{
        //    gameObject.SetActive(true);

        //    iItems[currentItem].gameObject.SetActive(true);
        //}



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowItem(string itemName)
    {
        //for (int i = 0; i < iItems.Length; i++)
        //{
        //    if (iItems[i].iItemName == itemName)
        //    {
        //        currentItem = i;
        //        gameObject.SetActive(true);
        //        iItems[i].gameObject.SetActive(true);
        //    }
        //}

        gameObject.SetActive(true);
        iItem.gameObject.SetActive(true);
    }

    public void DesactiveBox()
    {
        iItems[currentItem] = null;
        gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!isSelected) {

            GetComponent<UnityEngine.UI.Image>().color = Color.red;
            isSelected = true;
        }
        else
        {
            //ColorUtility.TryParseHtmlString("#E4CFC0FF", out myColor);
            GetComponent<UnityEngine.UI.Image>().color = new Color32(228, 207, 192, 255);
            isSelected = false;
        }
    }


}
