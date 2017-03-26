using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	TrailRenderer tail;
	VariableManager vm;
	// Use this for initialization
	void Start () {
		tail = this.gameObject.GetComponent<TrailRenderer> ();
		Destroy (this.gameObject, 10f);
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Stadium Terrain" && vm.GetBatHitFlag()) {
			int temp = vm.GetBallBounceCount ();
			temp++;
			vm.SetBallBounceCount (temp);
		}
	}

}
