using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Mouse down");

    }

    void OnMouseDown()
    {

        //Debug.Log("Mouse down method");

        //if (!dMan.dialogActive)
        //{
            //Debug.Log("Mouse down method activated");
            dMan.dialogLines = dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialog();
        //}

    }
}
