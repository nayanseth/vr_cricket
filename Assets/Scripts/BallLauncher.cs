using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallLauncher : MonoBehaviour {

	public bool hapticFeedbackFlag;
	SteamVR_Controller.Device device;
	GameObject launchPad, controller, ball;
	Vector3 position;
	public Vector3 velocity;
	AudioSource audio;
	public AudioClip pitch;

	public float randomX, randomY, randomZ, forceMultiplier;


	void Awake () {
		hapticFeedbackFlag = false;
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
				randomZ = UnityEngine.Random.Range(-3f,-1f);
				randomX = UnityEngine.Random.Range(0f,0.06f);

				if(randomZ>-2f){
					randomY = UnityEngine.Random.Range(-0.199f,-0.1f);
					forceMultiplier = 500f;
				} else {
					randomY = UnityEngine.Random.Range(-0.3f,-0.2f);
					forceMultiplier = 250f;
				}
				ball.GetComponent<Rigidbody> ().AddForce (new Vector3(randomX,randomY,randomZ) * forceMultiplier);
				//ball.GetComponent<Rigidbody> ().AddForce (controller.transform.forward/*new Vector3(randomX,0,randomZ)*/ * 500f);
				//print(controller.transform.forward);
			}

			if (hapticFeedbackFlag) {
				device.TriggerHapticPulse (2500);
				hapticFeedbackFlag = false;
			}
		} catch (NullReferenceException e) {
			print("Trying to connnect to controller!");
		}
	}


}
