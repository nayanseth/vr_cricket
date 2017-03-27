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
	int check;
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
		check = score - milestoneCheck;
		if (((check<=5 && check>=0) && vm.GetPlayFireworksFlag ()) || (check<=5 && check>=0)) {
			vm.SetPlayFireworksFlag (false);
			PlayFireworks ();
			tm.SetMilestoneText (milestoneCheck.ToString() + " Scored");
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

	public void SetMilestoneCheck(int value) {
		milestoneCheck = value;
	}

}
