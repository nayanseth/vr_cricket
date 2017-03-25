using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallLauncher : MonoBehaviour {

	public bool flag;
	SteamVR_Controller.Device device;
	GameObject ball;
	GameObject launchPad;
	Vector3 position;
	public Vector3 velocity;
	AudioSource audio;
	public AudioClip pitch;
	GameObject controller;

	void Awake () {
		flag = false;
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		launchPad = GameObject.Find ("Launch Pad");
		controller = GameObject.Find ("Controller (right)");
	}

	void FixedUpdate () {
		try{
			device = controller.GetComponent<ControllerManager>().device;
			velocity = device.velocity;
		

			position = launchPad.transform.position;

			if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				audio.clip = pitch;
				audio.Play ();
				ball = Instantiate (Resources.Load ("Prefabs/Cricket Ball"), position, launchPad.transform.rotation) as GameObject;
				ball.GetComponent<Rigidbody> ().AddForce (/*launchPad.transform.forward*/controller.transform.forward * 500f);
				print(controller.transform.forward);
			}

			if (flag) {
				device.TriggerHapticPulse (3500);
				flag = false;
			}
		} catch (NullReferenceException e) {
			print("Trying to connnect to controller!");
		}
	}


}
