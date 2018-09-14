using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public AudioClip Clicksound;
    AudioSource MyAudio;
    // Use this for initialization

    public static SoundManager instance;

    private void Awake()
    {
        if (SoundManager.instance = null)
            SoundManager.instance = this;
    }

    void Start () {
        MyAudio = GetComponent<AudioSource>();

		
	}
    public void PlaySound()
    {
        MyAudio.clip = Clicksound;
        MyAudio.Play();
    }
 

    // Update is called once per frame
    void Update () {
		
	}
}
