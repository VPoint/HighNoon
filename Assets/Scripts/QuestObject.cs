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

    public bool pickedUp;
    public bool used;


    //private static bool qObjExists;

    // Use this for initialization
    void Start()
    {
        //theQM = FindObjectOfType<QuestManager>();
        //if (!qObjExists)
        //{
        //    qObjExists = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        //startingScene = SceneManager.GetActiveScene();

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

            if (theQM.itemCollected == otherItemValue)
            {
                theQM.itemCollected = null;
                EndQuest();
            }

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
