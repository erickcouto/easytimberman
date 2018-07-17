using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour {


    public static Soundmanager instance;

    public AudioSource effects;

    public AudioClip play;
    public AudioClip death;
    public AudioClip cut;

	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;

        }
        else {
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound(AudioClip audio) {
        effects.clip = audio;
        effects.Play();


    }

}
