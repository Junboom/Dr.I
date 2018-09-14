using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {


    public static int score;
    public static int Excellent = 100;
    public static int Good = 60;
    public static int Bad = 20;
    public static int Miss = 0;

    

    private void Awake()
    {

        score = 0;



    }


    public static void GetPoint(GameObject obj)
    {

        if (RayCaster.distance < 3 && RayCaster.distance > 0)
        {
            GameObject.Find("EffectManager").GetComponent<EffectManager>().ExcellentBomb(obj.transform.position);
            GameObject.Find("EffectManager").GetComponent<EffectManager>().ComboBomb();
            Score_Manager.score += Score_Manager.Excellent;
            ComboManager.combo++;
        }
        else if (RayCaster.distance < 5 && RayCaster.distance >= 3)
        {
            GameObject.Find("EffectManager").GetComponent<EffectManager>().GoodBomb(obj.transform.position);
            GameObject.Find("EffectManager").GetComponent<EffectManager>().ComboBomb();
            Score_Manager.score += Score_Manager.Good;
            ComboManager.combo++;
        }
        else if (RayCaster.distance < 8 && RayCaster.distance >= 5)
        {
            GameObject.Find("EffectManager").GetComponent<EffectManager>().BadBomb(obj.transform.position);
            GameObject.Find("EffectManager").GetComponent<EffectManager>().ComboBomb();
            Score_Manager.score += Score_Manager.Bad;
            ComboManager.combo++;
        }
        else
        {
            Score_Manager.score += Score_Manager.Miss;
            ComboManager.combo = 0;
        }
        
        RayCaster.distance = 0;
    }




}
