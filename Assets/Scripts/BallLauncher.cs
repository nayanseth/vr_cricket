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
				randomZ = UnityEngine.Random.Range(-2f,-1f);
				randomX = UnityEngine.Random.Range(0f,0.06f);
				randomY = -0.1f;
				if(randomZ<-1f && randomZ>=-1.3f){
					randomY = UnityEngine.Random.Range(-0.35f,-0.1f);
					if(randomY<=-0.3f && randomY>=-0.35f) {
						forceMultiplier = UnityEngine.Random.Range(450f,500f);
					} else {
						// Slow Bouncer and Good Length
						forceMultiplier = UnityEngine.Random.Range(500f,600f);
					}

				} else if(randomZ<-1.3f && randomZ>=-1.6f) {
					// Full Length
					forceMultiplier = UnityEngine.Random.Range(350f,400f);
				} else if(randomZ<-1.6 && randomZ>=-2f) {
					// Yorker
					forceMultiplier = UnityEngine.Random.Range(350f,400f);
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
