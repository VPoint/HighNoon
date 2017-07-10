using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

    private static bool qTrigExists;

    // Use this for initialization
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();

        if (!qTrigExists)
        {
            qTrigExists = true;
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

        if (!theQM.questCompleted[questNumber])
        {
            //Debug.Log("Mouse down method activated");
            if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.quests[questNumber].gameObject.SetActive(true);
                theQM.quests[questNumber].StartQuest();
            }

            if (endQuest && theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.quests[questNumber].EndQuest();
            }


        }

    }
}
