using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    private void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    public void NextLevelButton(int index)
     {
         Application.LoadLevel(index);
     }
 
     public void NextLevelButton(string levelName)
     {
         Application.LoadLevel(levelName);
     }
}
