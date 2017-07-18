using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Action : MonoBehaviour, IPointerDownHandler
{

    private GameModel theGM;
	private GameModel.State buttonState;
    public int instructionID;
	public Image buttonImage;
	public Sprite selected;
	public Sprite deselected;
	private bool active;

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
			active = true;
		} else {
			buttonImage.sprite = deselected;
			active = false;
		}
    }

     public void OnPointerDown (PointerEventData eventData)
    {
        //Debug.Log("Action Selected");
		if(theGM.currState != buttonState){
			theGM.SetState(instructionID);
		} else {
			theGM.SetState(0);
		}
    }
}