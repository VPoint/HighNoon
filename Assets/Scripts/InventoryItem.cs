using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    public int iBoxNumber;
    public InventoryManager theIM;
    public string iItemName;

    public GameModel theGM;


    // Use this for initialization
    void Start()
    {

        theIM = FindObjectOfType<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        theGM.PerformActionOnSelected(iItemName);
    }


}
