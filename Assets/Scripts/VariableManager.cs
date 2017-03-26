using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VariableManager : MonoBehaviour {
	int score, ballCount, bouncerCount;
	float nrr;
	public int ballBounceCount;
	public bool batHit;
	public bool boundaryFlag;

	void Start () {
		boundaryFlag = false;
		batHit = false;
		score = 0;
		ballCount = 0;
		bouncerCount = 0;
		ballBounceCount = 0;
	}


	public int GetBallCount (){
		return ballCount;
	}

	public int GetScoreCount (){
		return score;
	}

	public int GetBouncerCount (){
		return bouncerCount;
	}

	public void SetBallCount (int value){
		ballCount = value;
	}

	public void SetScoreCount (int value){
		score = value;
	}

	public void SetBouncerCount (int value){
		bouncerCount = value;
	}

	public float GetNRR() {
		
		float remainingBalls = (float)(6-(ballCount % 6));
		//print (remainingBalls);
		float newBallCount = ballCount + remainingBalls;
		//print (newBallCount);
		float expectedRuns = ((float)(score*newBallCount)) / ballCount;
		//print (expectedRuns);
		nrr = expectedRuns / (newBallCount / 6);
		//print (nrr);
		return nrr;
	}

	public bool GetBoundaryFlag() {
		return boundaryFlag;
	}

	public void SetBoundaryFlag(bool flag) {
		boundaryFlag = flag;
	}

	public bool GetBatHitFlag() {
		return batHit;
	}

	public void SetBatHitFlag(bool flag) {
		batHit = flag;
	}

	public int GetBallBounceCount() {
		return ballBounceCount;
	}

	public void SetBallBounceCount(int value) {
		ballBounceCount = value;
	}

}
