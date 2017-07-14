using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public InventoryBox[] iBoxes;

    public string iItemCollected;

    private static bool imExists;
	
	private bool active;
    // Use this for initialization
    void Start()
    {

        if (!imExists)
        {
            imExists = true;
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
	
	public void resetManager(){
		imExists = false;
		iBoxes = null;
		Destroy(gameObject);
	}
	
	public void deactivateInventory(){
		if(active){
			gameObject.SetActive(!active);
			active = false;
		}
	}
	
	public void activateInventory(){
		if(!active){
			gameObject.SetActive(!active);
			active = true;
		}
	}
}
