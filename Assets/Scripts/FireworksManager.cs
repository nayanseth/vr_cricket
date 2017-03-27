using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksManager : MonoBehaviour {
	bool playFireworks;
	public AudioClip fireworks;
	AudioSource audio;
	VariableManager vm;
	int score;
	int milestoneCheck;

	TextManager tm;
	// Use this for initialization
	void Start () {
		milestoneCheck = 50;
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		score = vm.GetScoreCount ();
		if ((milestoneCheck-score<=5 && vm.GetPlayFireworksFlag ()) || (milestoneCheck-score<=5)) {
			vm.SetPlayFireworksFlag (false);
			PlayFireworks ();
			milestoneCheck += 50;

		} else if (vm.GetPlayFireworksFlag ()) {
			vm.SetPlayFireworksFlag (false);
			PlayFireworks ();
		}
	}

	public void PlayFireworks() {
		audio.clip = fireworks;
		audio.Play ();
		Instantiate (Resources.Load ("Prefabs/Fireworks Right"));
		Instantiate (Resources.Load ("Prefabs/Fireworks Left"));
	}

}
