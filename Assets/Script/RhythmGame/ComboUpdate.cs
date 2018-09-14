using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboUpdate : MonoBehaviour {

    Text comboLabel;
	// Use this for initialization
	void Start ()
    {
        comboLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        comboLabel.text = ComboManager.combo.ToString() + " Combo!";
        

    }
}
