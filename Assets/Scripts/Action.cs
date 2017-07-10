using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{

    private GameModel theGM;
    public int instructionID;

    // Use this for initialization
    void Start()
    {
        theGM = FindObjectOfType<GameModel>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        theGM.SetState(instructionID);
    }
}
