using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    GameObject obj;
    void Start()
    {
        obj = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Swalling();

    }

    public void Swalling()
    {

        if (obj.activeSelf)
        {
            transform.localScale -= new Vector3(0.015F, 0.015F, 0);
            if(transform.localScale.x < 0.9 && transform.localScale.y < 0.9)
            {
                Score_Manager.GetPoint(obj);
                transform.localScale = new Vector3(3F, 3F, 0);
                obj.SetActive(false);
            }
        }  


    }



}
