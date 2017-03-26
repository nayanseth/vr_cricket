using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksManager : MonoBehaviour {
	bool playFireworks;
	public AudioClip fireworks;
	AudioSource audio;
	VariableManager vm;
	// Use this for initialization
	void Start () {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (vm.GetPlayFireworksFlag ()) {
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
