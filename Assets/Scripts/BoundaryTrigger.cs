using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour {

	VariableManager vm;

	void Start() {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball" && vm.GetBatHitFlag()) {
			print ("yo");
			if (!vm.GetBoundaryFlag ()) {
				vm.SetBoundaryFlag (true);
			}
		}
	}
}
