using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;
    private QuestManager theQM;
    public string itemName;

    //i added
    public int iBoxNumber;
    private InventoryManager theIM;

    private static bool qItemExists;



    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
        theIM = FindObjectOfType<InventoryManager>();
        gameObject.SetActive(true);

        if (!qItemExists)
        {
            qItemExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse down method");

        if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            //Debug.Log("Mouse down method activated");
            theQM.itemCollected = itemName;
            theIM.iItemCollected = itemName;

            //theIM.iBoxes[iBoxNumber].gameObject.SetActive(true);
            theIM.iBoxes[iBoxNumber].ShowItem(itemName);
            gameObject.SetActive(false);
        }

            

            

            


        

    }


}
