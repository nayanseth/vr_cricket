using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	string score,overs,nrr,speed;
	Text scoreText, oversText, nrrText,speedText, nameText, milestoneText, commentaryText, bowlingTypeText;

	void Awake() {
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
		oversText = GameObject.Find ("Overs").GetComponent<Text> ();
		nrrText = GameObject.Find ("NRR").GetComponent<Text> ();
		speedText = GameObject.Find ("Speed").GetComponent<Text> ();
		nameText = GameObject.Find ("Name").GetComponent<Text> ();
		milestoneText = GameObject.Find ("Milestone").GetComponent<Text> ();
		bowlingTypeText = GameObject.Find ("Bowling Type").GetComponent<Text> ();
		commentaryText = GameObject.Find ("Commentary").GetComponent<Text> ();
	}

	public void SetScoreText(string value) {
		scoreText.text = value;
	}

	public void SetOversText(string value) {
		oversText.text = value;
	}

	public void SetNRRText(string value) {
		nrrText.text = value;
	}

	public void SetSpeedText(string value) {
		speedText.text = value;
	}

	public void SetNameText(string value) {
		nameText.text = value;
	}

	public void SetMilestoneText(string value) {
		milestoneText.text = value;
	}

	public void SetBowlingTypeText(string value) {
		bowlingTypeText.text = value;
	}
	public void SetCommentaryText(string value) {
		commentaryText.text = value;
	}




}
