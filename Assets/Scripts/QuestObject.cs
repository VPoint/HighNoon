using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;

    public QuestManager theQM;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool needsOtherItemApplied;
    public string otherItemValue;
    public static string lastTargetItem;

    //private static bool qObjExists;

    // Use this for initialization
    void Start()
    {
        //if (!qObjExists)
        //{
        //    qObjExists = true;
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



        if (isItemQuest)
        {
            if (theQM.itemCollected == targetItem)
            {
                lastTargetItem = targetItem;
                theQM.itemCollected = null;

                EndQuest();
            }
            
        }
        if (needsOtherItemApplied)
        {
            if (theQM.questCompleted[questNumber - 1])
            {
                theQM.itemCollected = lastTargetItem;

                if(theQM.itemCollected == otherItemValue)
                {
                    theQM.itemCollected = null;
                    EndQuest();
                }
            }

        }
    }

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
