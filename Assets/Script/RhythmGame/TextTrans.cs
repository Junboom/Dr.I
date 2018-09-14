using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTrans : MonoBehaviour {


    public static string text;
  


    // Use this for initialization
    void Start () {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            text = "/text/windsong.txt"; 
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            text = "/text/Maybe.txt";
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            text = "/text/Lastcarnival.txt";
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            text = "/text/DGM.txt";
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
