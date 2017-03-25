using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	TrailRenderer tail;

	// Use this for initialization
	void Start () {
		tail = this.gameObject.GetComponent<TrailRenderer> ();
		Destroy (this.gameObject, 5f);

	}

}
