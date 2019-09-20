using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashStretch : MonoBehaviour {

    Animator anim;
    public AudioClip splatSound;
    public AudioSource playerAudioSource;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerAudioSource.clip = splatSound;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("Squash");
        playerAudioSource.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetTrigger("Stretch");
    }
}
