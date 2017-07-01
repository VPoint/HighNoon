using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;

    private QuestManager theQM;

    public string itemName;



    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();

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

            gameObject.SetActive(false);


        }

    }


}
