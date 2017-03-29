using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VariableManager : MonoBehaviour {
	int score, ballCount, bouncerCount;
	float nrr;
	bool playFireworks, fastBowling, batHit, fastSpin, spinBowling;

	void Start () {
		batHit = false;
		score = 0;
		ballCount = 0;
		bouncerCount = 0;
		playFireworks = false;
		//fastBowling = false;
		//fastSpin = false;
	}

	public bool GetSpinBowling() {
		return spinBowling;
	}

	public void SetSpinBowling(bool value){
		spinBowling = value;
	}

	public bool GetFastSpin() {
		return fastSpin;
	}

	public void SetFastSpin(bool value){
		fastSpin = value;
	}

	public bool GetBatHit() {
		return batHit;
	}

	public void SetBatHit(bool value){
		batHit = value;
	}

	public bool GetFastBowling() {
		return fastBowling;
	}

	public void SetFastBowling(bool value){
		fastBowling = value;
	}

	public bool GetPlayFireworksFlag() {
		return playFireworks;
	}

	public void SetPlayFireworksFlag(bool value){
		playFireworks = value;
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
		
		/*float remainingBalls = (float)(6-(ballCount % 6));
		float newBallCount = ballCount + remainingBalls;
		float expectedRuns = ((float)(score*newBallCount)) / ballCount;*/
		nrr = ((float)score/ballCount)* 6;

		return nrr;
	}

}
