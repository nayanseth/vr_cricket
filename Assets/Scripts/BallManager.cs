using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	TrailRenderer trail;
	bool batHitFlag;
	int ballBounceCount, score;
	float distance;
	VariableManager vm;
	TextManager tm;
	// Use this for initialization
	void Start () {
		batHitFlag = false;
		ballBounceCount = 0;
		vm = GameObject.Find("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find("Managers").GetComponent<TextManager> ();
		trail = this.gameObject.GetComponent<TrailRenderer> ();
		Destroy (this.gameObject, 8f);

	}

	void FixedUpdate() {
		distance = Vector3.Magnitude (this.gameObject.transform.position);

		if (distance > 85f && batHitFlag) {
			batHitFlag = false;
			score = vm.GetScoreCount ();
			if (ballBounceCount > 0) {
				score += 3;
			} else {
				vm.SetPlayFireworksFlag (true);
				score += 5;
			}

			vm.SetScoreCount (score);
			tm.SetScoreText (score.ToString());
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Bat") {
			batHitFlag = true;
		}

		if (batHitFlag && other.gameObject.name == "Stadium Terrain") {
			ballBounceCount++;
		}
	}

}
