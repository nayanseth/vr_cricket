using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetBowlingType : MonoBehaviour {

	Text bowlingText;
	BowlingManager bm;
	bool fastBowlingFlag, fastSpinFlag, spinBowlingFlag;

	// Use this for initialization
	void Start () {

		bm = GameObject.Find ("Bowling Manager").GetComponent<BowlingManager> ();
	}
	
	public void GetBowling(GameObject bowling) {
		bowlingText = bowling.GetComponentInChildren<Text> ();

		if (bowlingText.text.Trim () == "SPIN") {
			spinBowlingFlag = true;
			fastBowlingFlag = false;
			fastSpinFlag = false;

		} else if(bowlingText.text.Trim () == "FAST") {
			fastBowlingFlag = true;
			spinBowlingFlag = false;
			fastSpinFlag = false;

		} else if(bowlingText.text.Trim () == "FAST & SPIN") {
			fastSpinFlag = true;
			spinBowlingFlag = false;
			fastBowlingFlag = false;
		}
		bm.SetFastBowling (fastBowlingFlag);
		bm.SetSpinBowling (spinBowlingFlag);
		bm.SetFastSpinBowling (fastSpinFlag);


		SceneManager.LoadScene ("Scene Selector");
	
	}
}
