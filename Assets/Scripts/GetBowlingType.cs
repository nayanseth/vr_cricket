using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetBowlingType : MonoBehaviour {

	Text bowlingText;
	BowlingManager bm;
	bool fastBowlingFlag;

	// Use this for initialization
	void Start () {

		bm = GameObject.Find ("Bowling Manager").GetComponent<BowlingManager> ();
	}
	
	public void GetBowling(GameObject bowling) {
		bowlingText = bowling.GetComponentInChildren<Text> ();

		if (bowlingText.text.Trim () == "SPIN") {
			fastBowlingFlag = false;
		} else if(bowlingText.text.Trim () == "FAST") {
			fastBowlingFlag = true;
		}

		bm.SetFastBowling (fastBowlingFlag);

		SceneManager.LoadScene ("Main");
	
	}
}
