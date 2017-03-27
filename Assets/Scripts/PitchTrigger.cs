using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PitchTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {

			try {
				other.gameObject.GetComponent<SpinBall> ().pitchHit = true;
			} catch (NullReferenceException e) {
			}

		}
	}
}
