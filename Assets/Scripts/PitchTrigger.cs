using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {
			other.gameObject.GetComponent<SpinBall> ().pitchHit = true;
		}
	}
}
