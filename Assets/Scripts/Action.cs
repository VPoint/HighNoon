using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action : Button
{

    private GameModel theGM;
	private GameModel.State buttonState;
    public int instructionID;
	public Image buttonImage;
	public Sprite selected;
	public Sprite deselected;

    // Use this for initialization
    void Start()
    {
        theGM = FindObjectOfType<GameModel>();
		buttonState = (GameModel.State)(instructionID);

    }

    // Update is called once per frame
    void Update()
    {
		if(theGM.currState == buttonState){
			//Debug.Log("Show pressed");
			buttonImage.sprite = selected;
		} else {
			buttonImage.sprite = deselected;
		}
    }

    public void changeState()
    {
        //Debug.Log("Action Selected");
		if(theGM.currState != buttonState){
			theGM.SetState(instructionID);
		} else {
			theGM.SetState(0);
		}
    }
}
