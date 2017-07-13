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
                theQM.itemCollected = null;

                Debug.Log("Arrived here1");

                EndQuest();
                Debug.Log("Arrived here2");
            }

        }
        //if (needsOtherItemApplied && used)
        if (used)
        {

            EndQuest();

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
