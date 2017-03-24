using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath : MonoBehaviour {

	public AudioClip shot;
	AudioSource audio;

	void Start() {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		
	}

	void OnCollisionEnter(Collision other){
		audio.clip = shot;

		if(other.gameObject.tag=="Ball") {
			audio.Play ();
		}
	
	}
}
