using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NameManager : MonoBehaviour {
	string name;
	PlayerManager pm;
	TextManager tm;
	// Use this for initialization
	void Start () {
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();

		try{

			pm = GameObject.Find ("Player Manager").GetComponent<PlayerManager> ();
			name = pm.GetName ();
			print(name);
			tm.SetNameText ("Hi " + name);
			Destroy (GameObject.Find ("Player Manager"));

		} catch (NullReferenceException e) {
			print ("Name could not be loaded");
		}


			
	}
}
