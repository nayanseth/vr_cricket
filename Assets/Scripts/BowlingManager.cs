using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManager : MonoBehaviour {

	bool fastBowling;

	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetFastBowling(bool value) {
		fastBowling = value;
	}

	public bool GetFastBowling(){
		return fastBowling;
	}
}
