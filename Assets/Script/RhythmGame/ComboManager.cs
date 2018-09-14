using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {
    public static float comboAlpha;
    public static float comboScale;
    private Vector4 origin;
    public GameObject comboObj;
    public Text comboText;
    public static int combo;
	// Use this for initialization
	void Start () {
        combo = 0;
        origin = comboText.material.color;


    }
    private void Update()
    {
        if (combo < 4) comboObj.SetActive(false);
        else comboObj.SetActive(true);

        if (comboAlpha >= 0f)
        {
            comboObj.transform.localScale = new Vector3(comboScale, comboScale, 1);
            comboText.material.color = new Vector4(origin.x, origin.y, origin.z, comboAlpha);
            comboScale -= 0.01f;
            comboAlpha -= 0.01f;
        }

    }
}
