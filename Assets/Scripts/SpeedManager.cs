using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour {
	TextManager tm;
	void Start () {
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {
			try {
				tm.SetSpeedText (((int)other.gameObject.GetComponent<Rigidbody>().velocity.magnitude*3.6).ToString() + "Km/hr");
			} catch (NullReferenceException e) {
			}
		}

		Destroy (this.gameObject.GetComponent<SpeedManager>());
	}
}
