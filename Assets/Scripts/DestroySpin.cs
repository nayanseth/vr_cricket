using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpin : MonoBehaviour {

	VariableManager vm;

	void Start() {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball" && vm.GetSpinBowling() && !vm.GetBatHit()) {

			Destroy (other.gameObject);

		}
	}
}
