using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBall1x : MonoBehaviour {

	public bool pitchHit;
	VariableManager vm;
	BallLauncher1x bl;
	void Start () {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		pitchHit = false;		
		bl = GameObject.Find ("Managers").GetComponent<BallLauncher1x> ();
	}

	void FixedUpdate() {

		if (pitchHit && !vm.GetBatHit ()) {
			if (bl.randomX >= -0.08f && bl.randomX <= -0.01f){
				this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.05f, 0f, 0f) * 0.28f, ForceMode.Impulse);
			} else if (bl.randomX >= 0.02f && bl.randomX <= 0.08f){
				this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (-0.05f, 0f, 0f) * 0.28f, ForceMode.Impulse);
			}

			/*if (bl.randomX >= -0.08f && bl.randomX <= -0.01f){
				this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.05f, 0f, 0f) * 0.28f, ForceMode.Impulse);
			} else if (bl.randomX >= 0.02f && bl.randomX <= 0.08f){
				this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (-0.05f, 0f, 0f) * 0.28f, ForceMode.Impulse);
			}*/

		} else {
			pitchHit = false;
		}

	}
}
