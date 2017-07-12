using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestObject : MonoBehaviour
{

    public int questNumber;

    public QuestManager theQM;
    public GameModel theGM;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool needsOtherItemApplied;
    public string otherItemValue;
    public static string lastTargetItem;

    public bool isPuzzleQuest;

    public bool pickedUp;
    public bool used;
    public bool solved;
    public bool combined;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Arrived here at least");
        if (isItemQuest && pickedUp)
        {
            //Debug.Log("current collected" + theQM.itemCollected.ToString());
            if (theQM.itemCollected == targetItem)
            {
                lastTargetItem = targetItem;
                theQM.itemCollected = null;

                Debug.Log("Arrived here1");

                EndQuest();
                Debug.Log("Arrived here2");
            }

        }
        if (needsOtherItemApplied && used)
        {
            
            theQM.itemCollected = lastTargetItem;
            Debug.Log("Item Collected " + theQM.itemCollected);
            Debug.Log("Last Target Item " + lastTargetItem);
            Debug.Log("Other Item Value " + otherItemValue);

            if (theQM.itemCollected == otherItemValue)
            {
                theQM.itemCollected = null;
                EndQuest();
            }

        }

        if (solved)
        {
            EndQuest();
        }

        if (combined)
        {
            EndQuest();
        }

    }

    //public bool allRqCompleted()
    //{
    //    if(questNumber == 0)
    //    {
    //        return true;
    //    }
    //    else { 
    //        for (int i = 0; i < preRq.Length; i++)
    //        {
    //            if (theQM.questCompleted[preRq[i]] == false)
    //                return false;
    //        }
    //            return true;
    //    }
    //}

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
