using UnityEngine;


public class AllLightOnOff : MonoBehaviour {
    public static bool isAllFireOn = false;
    private GameObject[] fireLight = new GameObject[7];
    private GameObject[] eventObject = new GameObject[5];

	// Use this for initialization
	void Start ()
    {
		for(int i=0; i<6; i++)
        {
            fireLight[i] = GameObject.Find("Fire_Torch" + i.ToString());
        }
        fireLight[fireLight.Length - 1] = GameObject.Find("WallFireEffects");

        eventObject[0] = GameObject.Find("NoticeBoard");
        eventObject[1] = GameObject.Find("OpenBarrelObject");
        eventObject[2] = GameObject.Find("FishBoard");
        eventObject[3] = GameObject.Find("EventFirewood1");
        eventObject[4] = GameObject.Find("RoundTableObj");

        FireOff();
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    public void FireOn()
    {
        isAllFireOn = true;
        for(int i=0; i<fireLight.Length; i++)
            fireLight[i].SetActive(true);
        SetEventColliderEnabled(true);
    }

    public void FireOff()
    {
        isAllFireOn = false;
        for(int i=0; i<fireLight.Length; i++)
            fireLight[i].SetActive(false);
        SetEventColliderEnabled(false);
    }

    public void SetEventColliderEnabled(bool a)
    {
        if(a)
        {
            for(int i=0; i<eventObject.Length; i++)
            {
                if(i == 3) eventObject[i].GetComponent<Transform>().parent.GetComponent<BoxCollider>().enabled = false;
                else eventObject[i].GetComponent<MeshCollider>().enabled = true;
            }
        }
        else
        {
            for(int i=0; i<eventObject.Length; i++)
            {
                if(i == 3) eventObject[i].GetComponent<Transform>().parent.GetComponent<BoxCollider>().enabled = false;
                else eventObject[i].GetComponent<MeshCollider>().enabled = false;
            }
        }
    }
   
    public void SetEmissionEnabled(bool a, int i)
    {
        if(a)
        {
            if(i == 3)
            {
                for(int j=1; j<8; j++)
                {
                    GameObject.Find("EventFirewood" + j).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    GameObject.Find("EventFirewood" + j).GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 255f, 255f, 120f));
                    DynamicGI.SetEmissive(GameObject.Find("EventFirewood" + j).GetComponent<Renderer>(), new Color(3f, 3, 3, 3f));
                }
            }
            else
            {
                eventObject[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                eventObject[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 255f, 255f, 120f));
                DynamicGI.SetEmissive(eventObject[i].GetComponent<Renderer>(), new Color(3f, 3, 3, 3f));
            }
        }
        else
        {
            if(i == 3)
            {
                for(int j=1; j<8; j++)
                {
                    GameObject.Find("EventFirewood" + j).GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                    GameObject.Find("EventFirewood" + j).GetComponent<Renderer>().material.color = Color.white;
                    DynamicGI.SetEmissive(GameObject.Find("EventFirewood" + j).GetComponent<Renderer>(), Color.black);
                }
            }
            else
            {
                eventObject[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                eventObject[i].GetComponent<Renderer>().material.color = Color.white;
                DynamicGI.SetEmissive(eventObject[i].GetComponent<Renderer>(), Color.black);
            }
        }
    }
}
