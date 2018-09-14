using Jinwon.Coroutine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {

	// Use this for initialization
	void Start () {

 


        

    }
    
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartFadeAnim()
    {


        Invoke("SongFadeOut.StartFadeAnim", 2f);
    }

    public void FadeInOut2()
    {

     
            Invoke("SongFadeOut.StartFadeAnim", 2f);

        
    }
   
}


