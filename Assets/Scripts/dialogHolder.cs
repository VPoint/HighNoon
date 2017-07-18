using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;

    public bool canBeCombined;
    public bool canBePicked;
    public bool canBeUsed;
    private GameModel theGM;


    public string itemName;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        theGM = FindObjectOfType<GameModel>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Mouse down");

    }

    void OnMouseDown()
    {
        if (theGM.currState == GameModel.State.PICKUP)
        {
            dMan.ShowBox("This cannot be picked up.");
            Debug.Log("This cannot be picked up.");

        }
        else if (theGM.currState == GameModel.State.USE)
        {
            dMan.ShowBox("This cannot be used.");
            Debug.Log("This cannot be used.");

        }
        else if (theGM.currState == GameModel.State.COMBINE)
        {
            dMan.ShowBox("This cannot be combined.");
            Debug.Log("This cannot be combined.");
        }
        else
        {
            dMan.dialogLines = dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialog();
        }



        //Debug.Log("Mouse down method");

        //if (!dMan.dialogActive)
        //{
        //Debug.Log("Mouse down method activated");
        
        //}

    }
}
