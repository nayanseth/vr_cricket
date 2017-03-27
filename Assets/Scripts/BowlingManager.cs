using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManager : MonoBehaviour {

	bool fastBowling, spinBowling, fastSpin;
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetFastBowling(bool value) {
		fastBowling = value;
	}

	public bool GetFastBowling(){
		return fastBowling;
	}

	public void SetSpinBowling(bool value) {
		spinBowling = value;
	}

	public bool GetSpinBowling(){
		return spinBowling;
	}

	public void SetFastSpinBowling(bool value) {
		fastSpin = value;
	}

	public bool GetFastSpinBowling(){
		return fastSpin;
	}
}
