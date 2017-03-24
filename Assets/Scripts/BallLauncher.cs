using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {

	public bool flag;
	SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	GameObject ball;
	GameObject launchPad;
	Vector3 position, velocity;
	AudioSource audio;
	public AudioClip pitch;

	void Awake () {
		flag = false;
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		trackedObject = this.gameObject.GetComponent<SteamVR_TrackedObject>();
		launchPad = GameObject.Find ("Launch Pad");
	}

	void FixedUpdate () {
		
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		velocity = device.velocity;
		position = launchPad.transform.position;

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			audio.clip = pitch;
			audio.Play ();
			ball = Instantiate (Resources.Load ("Prefabs/Cricket Ball"), position, launchPad.transform.rotation) as GameObject;
			ball.GetComponent<Rigidbody> ().AddForce (transform.forward * 350f);

		}

		if (flag) {
			device.TriggerHapticPulse (3500);
			flag = false;
		}
	}


}
