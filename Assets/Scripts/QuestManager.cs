using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager theDM;

    public string itemCollected;

    private static bool qmExists;

    // Use this for initialization
    void Start()
    {
        
        questCompleted = new bool[quests.Length];

        if (!qmExists)
        {
            qmExists = true;
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
        theDM = FindObjectOfType<DialogueManager>();

    }

    public void ShowQuestText(string questText)
    {
		//Debug.Log("Show Quest Text");
        theDM.dialogLines = new string[1];
        theDM.dialogLines[0] = questText;

        theDM.currentLine = 0;

        //es removed
        theDM.ShowDialog();
    }
}
