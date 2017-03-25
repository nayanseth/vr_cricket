using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {

	public bool destroyMe;

	void Start () {
		destroyMe = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyMe) {
			destroyMe = false;
			StartCoroutine (PlaceStumps ());
		}
	}

	IEnumerator PlaceStumps() {
		yield return new WaitForSeconds (3f);
		DestroyImmediate (GameObject.Find("Stumps"));

		GameObject temp = Instantiate (Resources.Load ("Prefabs/Stumps")) as GameObject;
		temp.name = "Stumps";

	}
}
