using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour {

	public bool hapticFeedbackFlag;
	SteamVR_Controller.Device device;
	GameObject launchPad, controller, ball;
	Vector3 position;
	public Vector3 velocity;
	AudioSource audio;
	public AudioClip pitch;

	public float randomX, randomY, randomZ, forceMultiplier;
	string[] ballType = {"Short","Good","Full","Yorker","Bouncer"};
	public string selectedBall;

	VariableManager vm;
	TextManager tm;

	int ballCount, bouncerCount;

	void Awake () {
		hapticFeedbackFlag = false;
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		launchPad = GameObject.Find ("Launch Pad");
		controller = GameObject.Find ("Controller (right)");
		vm = this.gameObject.GetComponent<VariableManager> ();
		ballCount = vm.GetBallCount ();
		bouncerCount = vm.GetBouncerCount ();
		tm = this.gameObject.GetComponent<TextManager> ();
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

				randomX = UnityEngine.Random.Range(-0.02f,0.06f);
				randomY = -0.1f;
				randomZ = -2f;

				if(vm.GetBouncerCount()<3) {
					selectedBall = ballType[UnityEngine.Random.Range(0,ballType.Length)];
				} else {
					selectedBall = ballType[UnityEngine.Random.Range(0,ballType.Length-1)];
				}
				switch(selectedBall) {

				case "Short":
					randomZ = -1f;
					forceMultiplier = UnityEngine.Random.Range(500f,600f);
					break;
				case "Good":
					forceMultiplier = UnityEngine.Random.Range(250f,280f);
					break;
				case "Full":
					forceMultiplier = UnityEngine.Random.Range(250f,280f);
					randomY = UnityEngine.Random.Range(-0.05f,0f);
					break;
				case "Yorker":
					forceMultiplier = UnityEngine.Random.Range(250f,280f);
					randomY = UnityEngine.Random.Range(0.01f,0.05f);
					break;
				case "Bouncer":
					forceMultiplier = 500f;
					randomY = UnityEngine.Random.Range(-0.35f,-0.3f);
					randomZ = -1f;
					bouncerCount = vm.GetBouncerCount();
					vm.SetBouncerCount(++bouncerCount);
					break;
				}

				ballCount = vm.GetBallCount();
				vm.SetBallCount(++ballCount);

				if(vm.GetBallCount()%6==0) {
					vm.SetBouncerCount(0);
				}
				// Update Scoreboard
				tm.SetOversText(((int)ballCount/6).ToString() + "." + (ballCount%6).ToString() + " Overs");
				tm.SetNRRText(vm.GetNRR().ToString());
				ball.GetComponent<Rigidbody> ().AddForce (new Vector3(randomX,randomY,randomZ) * forceMultiplier);

				//ball.GetComponent<Rigidbody> ().AddForce (controller.transform.forward/*new Vector3(randomX,0,randomZ)*/ * 500f);
				//print(controller.transform.forward);

			}

			if (hapticFeedbackFlag) {
				device.TriggerHapticPulse (3000);
				hapticFeedbackFlag = false;
			}
		} catch (NullReferenceException e) {
			print("Trying to connnect to controller!");
		}
	}


}
