using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SetBowling : MonoBehaviour {


	BowlingManager bm;
	VariableManager vm;
	TextManager tm;
	SetBowlingText sbt;
	void Start () {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
		sbt = GameObject.Find ("Managers").GetComponent<SetBowlingText> ();
		try{

			bm = GameObject.Find ("Bowling Manager").GetComponent<BowlingManager> ();
			vm.SetFastBowling(bm.GetFastBowling());
			vm.SetSpinBowling(bm.GetSpinBowling());



			vm.SetFastSpin(bm.GetFastSpinBowling());
			if(bm.GetFastSpinBowling()) {
				vm.SetFastBowling(true);	// for first over;
			}
			StartCoroutine(WaitAndSetText());

				

			Destroy (GameObject.Find ("Bowling Manager"));
		} catch (NullReferenceException e) {
			print ("GameObject could not be found");
			//GameObject.Find ("Managers").RemoveComponent ();
		}

	}

	IEnumerator WaitAndSetText() {
		yield return new WaitForSeconds (1f);
		sbt.SetText();
	}
}
