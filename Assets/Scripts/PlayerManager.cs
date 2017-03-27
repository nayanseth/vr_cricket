using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
	string name;

	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetName(string value) {
		name = value;
	}

	public string GetName(){
		return name;
	}
	
}
