using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpsManager : MonoBehaviour {
	public AudioClip stumps;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball") {
			audio.clip = stumps;
			audio.Play ();
		}
	}
}
