using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountNum : MonoBehaviour {

	// Use this for initialization
	
        TextMesh CountDownNum;
        
    

    public void Awake()
    {
        CountDownNum = GetComponent<TextMesh>();
    }
    // Update is called once per frame
    void Update () {


        CountDownNum.text = System.Math.Floor(G2Score_Manager.CountNum).ToString();


    }

    

}
