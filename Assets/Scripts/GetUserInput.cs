using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GetUserInput : MonoBehaviour {
	SteamVR_Controller.Device device;
	GetName character;
	GameObject target;
	Laser l;
	string sceneName;
	GetBowlingType bowling;
	GetScene scene;
	// Use this for initialization
	void Start () {
		
		l = this.gameObject.GetComponent<Laser> ();
		sceneName = SceneManager.GetActiveScene ().name;

	}
	
	// Update is called once per frame
	void Update () {
		target = l.GetTarget ();
		try {
			device = this.gameObject.GetComponent<ControllerManager> ().device;
			if(device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				if(sceneName=="Player Info") {
					character = GameObject.Find ("Player Manager").GetComponent<GetName> ();
					character.GetCharacter(target);
					device.TriggerHapticPulse(3000);
				} else if(sceneName=="Bowling Info") {
					bowling = GameObject.Find ("Bowling Manager").GetComponent<GetBowlingType> ();
					bowling.GetBowling(target);
					device.TriggerHapticPulse(3000);
				} else if(sceneName == "Scene Selector") {
					scene = GameObject.Find ("Scene Manager").GetComponent<GetScene> ();
					scene.SetScene(target);
					device.TriggerHapticPulse(3000);
				}
			}



		} catch(NullReferenceException e) {
			print ("Trying to connect to controller");
		}
	}
}
