using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "Transparent Ball" || this.gameObject.name == "Transparent Ball (Clone)") {
			Destroy (this.gameObject, 1f);
		} else {

			Destroy (this.gameObject, 7f);
	
		}
	}

}
