using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    public int iBoxNumber;
    public InventoryManager theIM;
    public string iItemName;

    //private static bool iItemExists;
    public string collectedItem;

    public GameModel theGM;


    // Use this for initialization
    void Start()
    {

        theIM = FindObjectOfType<InventoryManager>();

        //if (!iItemExists)
        //{
        //    iItemExists = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        //DontDestroyOnLoad(transform.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (theGM.currState == GameModel.State.INSPECT)
        {
            //item.DisplayDescription();
        }
        else if (theGM.currState == GameModel.State.USE)
        {
            collectedItem = iItemName;
        }
        else if (theGM.currState == GameModel.State.PICKUP)
        {
            //AddToInventory(item);
        }

    }


}
