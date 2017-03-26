using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpsManager : MonoBehaviour {
	public AudioClip stumps;
	AudioSource audio;
	VariableManager vm;


	void Start () {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Bat") {
			audio.clip = stumps;
			audio.Play ();
			GameObject.Find ("Managers").GetComponent<GameObjectManager> ().destroyMe = true;
			vm.SetScoreCount(0);
			vm.SetBallCount (0);
			vm.SetBouncerCount (0);
		}
	}


}
