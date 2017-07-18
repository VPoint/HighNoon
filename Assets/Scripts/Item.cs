using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool canBeCombined;
    public bool canBePicked;
    public bool canBeUsed;
    private dialogHolder theDH;
    private DialogueManager theDM;
    private GameModel theGM;

    public string itemName;

    // Use this for initialization
    void Start()
    {
        theDH = FindObjectOfType<dialogHolder>();
        theDM = FindObjectOfType<DialogueManager>();
        theGM = FindObjectOfType<GameModel>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use()
    {

    }

    public void DisplayDescription()
    {

    }
    void OnMouseDown()
    {
        if (theGM.currState == GameModel.State.PICKUP)
        {
            theDM.ShowBox("This cannot be picked up.");
            Debug.Log("This cannot be picked up.");

        }
        else if (theGM.currState == GameModel.State.USE)
        {
            theDM.ShowBox("This cannot be used.");
            Debug.Log("This cannot be used.");

        }
        else if (theGM.currState == GameModel.State.COMBINE)
        {
            theDM.ShowBox("This cannot be combined.");
            Debug.Log("This cannot be combined.");
        }
        else
        {
            ShowItemDescription();
        }
    }

    public void ShowItemDescription()
    {
        //Debug.Log("show description!!");
        theDM.dialogLines = theDH.dialogueLines;
        theDM.currentLine = 0;
        theDM.ShowDialog();
    }
}

