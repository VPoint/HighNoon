using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;
    public bool[] questCompleted;
    public QuestTrigger[] qts;

    public DialogueManager theDM;

    public string itemCollected;
	public bool finalQuestComplete = false;

    private static bool qmExists;

    // Use this for initialization
    void Start()
    {
        if (!qmExists)
        {
            qmExists = true;
			questCompleted = new bool[quests.Length];
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

		if(questCompleted[questCompleted.Length - 1]){
			// if last quest completed, player has won
			Debug.Log("Final Quest Complete");
			finalQuestComplete = true;
		}
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
	
	public void resetManager(){
		qmExists = false;
		Destroy(gameObject);
	}
}
