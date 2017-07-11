using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

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

            if (!theQM.questCompleted[questNumber])
            {
                //Debug.Log("Mouse down method activated");
                if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();

                    //es added
                    //Destroy(gameObject);
                }

                if (endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].EndQuest();
                }

        }

        


    }

    //public bool allRqCompleted()
    //{
    //    if (questNumber == 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        for (int i = 0; i < preRq.Length; i++)
    //        {
    //            Debug.Log("Specific quest completed" + theQM.questCompleted[preRq[0]]);
    //            if (theQM.questCompleted[preRq[i]] == false)
    //                return false;
    //        }
    //        return true;
    //    }
    //}
}
