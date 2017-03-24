using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {


	SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	GameObject temp;
	GameObject launchPad;
	Vector3 position;

	void Awake () {
		trackedObject = this.gameObject.GetComponent<SteamVR_TrackedObject>();
		launchPad = GameObject.Find ("Launch Pad");
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		position = launchPad.transform.position;

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			temp = Instantiate (Resources.Load ("Prefabs/Cricket Ball"), position, launchPad.transform.rotation) as GameObject;
			temp.GetComponent<Rigidbody> ().AddForce (transform.forward * 300f);
		}
	}


}
