using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    public int iBoxNumber;
    public InventoryManager theIM;
    public string iItemName;

    private static bool iItemExists;

    // Use this for initialization
    void Start () {

        theIM = FindObjectOfType<InventoryManager>();

        if (!iItemExists)
        {
            iItemExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(transform.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
