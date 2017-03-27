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
	SetBowlingText sbt;
	void Awake () {
		sbt = GameObject.Find ("Managers").GetComponent<SetBowlingText> ();
		hapticFeedbackFlag = false;
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		launchPad = GameObject.Find ("Launch Pad");
		controller = GameObject.Find ("Controller (right)");
		vm = this.gameObject.GetComponent<VariableManager> ();
		ballCount = vm.GetBallCount ();
		bouncerCount = vm.GetBouncerCount ();
		tm = this.gameObject.GetComponent<TextManager> ();
		position = launchPad.transform.position;
	}

	void FixedUpdate () {
		try{
			device = controller.GetComponent<ControllerManager>().device;
			velocity = device.velocity;
		



			if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				vm.SetBatHit(false);
				audio.clip = pitch;
				audio.Play ();
				GameObject.Find("Speed Trigger").AddComponent<SpeedManager>();
				ball = Instantiate (Resources.Load ("Prefabs/Cricket Ball"), position, launchPad.transform.rotation) as GameObject;


				if(vm.GetFastBowling()) {

					randomX = UnityEngine.Random.Range(-0.01f,0.05f);
					randomY = 0f;
					randomZ = -1f;

					if(vm.GetBouncerCount()<3) {
						selectedBall = ballType[UnityEngine.Random.Range(0,ballType.Length)];
					} else {
						selectedBall = ballType[UnityEngine.Random.Range(0,ballType.Length-1)];
					}
					switch(selectedBall) {

					case "Short":
						randomY = -0.2f;
						forceMultiplier = UnityEngine.Random.Range(480f,485f);
						break;
					case "Good":
						randomZ = -1.55f;
						forceMultiplier = UnityEngine.Random.Range(300f,315f);
						break;
					case "Full":
						randomZ = -2.2f;
						forceMultiplier = UnityEngine.Random.Range(210f,230f);
						break;
					case "Yorker":
						forceMultiplier = UnityEngine.Random.Range(230f,260f);
						randomY = 0.1f;
						randomZ = -2f;
						break;
					case "Bouncer":
						forceMultiplier = 480f;
						randomY = -0.25f;
						randomZ = -1f;
						bouncerCount = vm.GetBouncerCount();
						vm.SetBouncerCount(++bouncerCount);
						break;
					}
				} 

				if(vm.GetSpinBowling()) {
					ball.AddComponent<SpinBall>();
					randomX = UnityEngine.Random.Range(-0.02f,0.04f);
					randomY = UnityEngine.Random.Range(0.12f,0.15f);
					randomZ = -1f;
					forceMultiplier = UnityEngine.Random.Range(300f,320f);
				} 

				// Ball Count

				ballCount = vm.GetBallCount();
				vm.SetBallCount(++ballCount);


				if(vm.GetBallCount()%6==0) {
					if(vm.GetFastSpin()) {
						bool temp = vm.GetFastBowling();
						temp = !temp;
						vm.SetFastBowling(temp);
						temp = vm.GetSpinBowling();
						temp = !temp;
						vm.SetSpinBowling(temp);

						sbt.SetText();
					}
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
