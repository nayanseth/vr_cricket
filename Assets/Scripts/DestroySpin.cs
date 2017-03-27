using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpin : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {
			other.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0.001f,0.001f,0.001f);
		}
	}
}
