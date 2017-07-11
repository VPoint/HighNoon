using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public InventoryBox[] iBoxes;

    public string iItemCollected;

    private static bool imExists;


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
}
