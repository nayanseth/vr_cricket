using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SetBowling : MonoBehaviour {


	BowlingManager bm;
	VariableManager vm;

	void Start () {
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();

		try{

			bm = GameObject.Find ("Bowling Manager").GetComponent<BowlingManager> ();
			vm.SetFastBowling(bm.GetFastBowling());
			Destroy (GameObject.Find ("Bowling Manager"));
		} catch (NullReferenceException e) {
			print ("Name could not be loaded");
			//GameObject.Find ("Managers").RemoveComponent ();
		}

	}
}
