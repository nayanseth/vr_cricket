using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {
	VariableManager vm;
	bool boundaryFlag, executionFlag;
	TextManager tm;
	public int score;
	// Use this for initialization
	void Start () {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
		executionFlag = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		boundaryFlag = vm.GetBoundaryFlag ();
		if (executionFlag && boundaryFlag) {
			executionFlag = false;
			ComputeFourSix ();
		}
	}

	void ComputeFourSix() {
		int ballBounceCount = vm.GetBallBounceCount ();

		if (ballBounceCount >= 1) {
			score = vm.GetScoreCount();
			score += 3;
			vm.SetScoreCount (score);
			tm.SetScoreText (score.ToString ());
		} else {
			score = vm.GetScoreCount();
			score += 5;
			vm.SetScoreCount (score);
			tm.SetScoreText (score.ToString ());
		}
		vm.SetBoundaryFlag (false);
		executionFlag = true;
		vm.SetBatHitFlag (false);
	}
}
