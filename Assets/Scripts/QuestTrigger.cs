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


}
