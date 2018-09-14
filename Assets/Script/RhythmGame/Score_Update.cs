using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Update : MonoBehaviour {


    Text scoreLabel;

	// Use this for initialization
	void Awake () {
        scoreLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

         scoreLabel.text = Score_Manager.score.ToString();
        //scoreLabel.text = "걸린 시간  : " + Score_Manager.checkTime.ToString();


    }
}
