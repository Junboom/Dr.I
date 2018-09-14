using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G2Score_Update : MonoBehaviour
{


    TextMesh G2scoreLabel;

    // Use this for initialization
    void Awake()
    {
        G2scoreLabel = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

        G2scoreLabel.text = "쳐다 본 시간  : " + G2Score_Manager.checkTime.ToString();


    }
}
