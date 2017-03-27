using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBowlingText : MonoBehaviour {

	TextManager tm;
	VariableManager vm;
	// Use this for initialization
	void Start () {
		
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
	}

	public void SetText() {
		// Commentary Text
		print("Got Called");

		if(vm.GetFastBowling()) {
			tm.SetBowlingTypeText("Fast Bowling");
		} else if(vm.GetSpinBowling()) {
			tm.SetBowlingTypeText("Spin Bowling");
		}
	}

}
