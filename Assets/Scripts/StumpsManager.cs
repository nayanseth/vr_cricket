using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpsManager : MonoBehaviour {
	public AudioClip stumps;
	AudioSource audio;



	void Start () {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Bat") {
			audio.clip = stumps;
			audio.Play ();
			GameObject.Find ("Managers").GetComponent<GameObjectManager> ().destroyMe = true;
			GameObject.Find ("Managers").GetComponent<VariableManager> ().score = 0;
		}
	}


}
