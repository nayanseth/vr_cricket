using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpsManager : MonoBehaviour {
	public AudioClip stumps;
	AudioSource audio;
	VariableManager vm;
	TextManager tm;
	FireworksManager fm;
	void Start () {
		fm = GameObject.Find ("Managers").GetComponent<FireworksManager> ();
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Bat") {
			audio.clip = stumps;
			audio.Play ();
			GameObject.Find ("Managers").GetComponent<GameObjectManager> ().destroyMe = true;
			vm.SetScoreCount(0);
			vm.SetBallCount (0);
			vm.SetBouncerCount (0);
			fm.SetMilestoneCheck (50);
			tm.SetMilestoneText ("Milestone: None");
		}
	}


}
