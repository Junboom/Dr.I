using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour {


    [SerializeField]
    public FoveInterfaceBase foveInterface;


    public static Ray ray;
    public static FoveInterfaceBase.EyeRays rays;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        rays = foveInterface.GetGazeRays();


    }
}
