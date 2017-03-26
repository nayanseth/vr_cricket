using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {
	SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;


	void Awake(){
		trackedObject = this.gameObject.GetComponent<SteamVR_TrackedObject>();
	}
	void FixedUpdate () {

		device = SteamVR_Controller.Input ((int)trackedObject.index);
	}
}
