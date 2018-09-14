using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {
    public static float distance;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
           // Debug.Log("Position : " + hit.transform.position);
           // Debug.Log("Point : " + hit.point);
           distance = Vector3.Magnitude((hit.transform.position + new Vector3(-2.7f, 2.7f, 0) - hit.point));

        }
	}


}
