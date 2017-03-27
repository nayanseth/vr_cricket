using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedManager : MonoBehaviour {
	TextManager tm;
	void Start () {
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {
			tm.SetSpeedText (((int)other.gameObject.GetComponent<Rigidbody>().velocity.magnitude*3.6).ToString() + "Km/hr");

		}

		Destroy (this.gameObject.GetComponent<SpeedManager>());
	}
}
