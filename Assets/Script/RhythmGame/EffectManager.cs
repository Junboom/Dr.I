using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
    public GameObject Excellent;
    public GameObject Good;
    public GameObject Bad;
    public ParticleSystem ExcellentEffect;
    public ParticleSystem GoodEffect;
    public ParticleSystem BadEffect;
    public ParticleSystem ExcellentEffectLight;
    public ParticleSystem GoodEffectLight;
    public ParticleSystem BadEffectLight;
    public ParticleSystem ComboEffect;

    // Use this for initialization
    void Start () {
        Excellent.transform.position = new Vector3(30, 30, 10);
        Good.transform.position = new Vector3(30, 30, 10);
        Bad.transform.position = new Vector3(30, 30, 10);
        ExcellentEffect.Stop();
        GoodEffect.Stop();
        BadEffect.Stop();
        ExcellentEffectLight.Stop();
        GoodEffectLight.Stop();
        BadEffectLight.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExcellentBomb(Vector3 position)
    {
        Excellent.transform.position = position;
        ExcellentEffect.Play();
        ExcellentEffectLight.Play();
    }
    public void GoodBomb(Vector3 position)
    {
        Good.transform.position = position;
        GoodEffect.Play();
        GoodEffectLight.Play();
    }
    public void BadBomb(Vector3 position)
    {
        Bad.transform.position = position;
        BadEffect.Play();
        BadEffectLight.Play();
    }
    public void ComboBomb()
    {
        ComboManager.comboScale = 1.5f;
        ComboManager.comboAlpha = 1f;
        ComboEffect.Play();
    }
}
