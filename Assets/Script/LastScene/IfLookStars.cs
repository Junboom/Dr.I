using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfLookStars : MonoBehaviour {

    [SerializeField]
    public FoveInterfaceBase foveInterface;

    public ParticleSystem[] star;
     


    private ParticleSystem.MinMaxGradient orgin;
    // Update is called once per frame
    private void Start()
    {
        orgin = star[1].main.startColor;
    }
    void Update () {
        
        //RaycastHit hitL, hitR;
        RaycastHit hit;


        //if (Physics.Raycast(l, out hitL, Mathf.Infinity, 1 << 12) && Physics.Raycast(r, out hitR, Mathf.Infinity, 1 << 12))
        if (Physics.Raycast(RayManager.rays.left, out hit, Mathf.Infinity, 1 << 12) ||
                Physics.Raycast(RayManager.rays.right, out hit, Mathf.Infinity, 1 << 12))
        {
            G2Score_Manager.checkTime += Time.deltaTime;
            for (int i = 0; i < star.Length; i++) star[i].startColor = new Color(1, 1, 0, 0.5f);

        }
        else
        {
            for (int i = 0; i < star.Length; i++) star[i].startColor = orgin.color;

        }
                


    }
}
