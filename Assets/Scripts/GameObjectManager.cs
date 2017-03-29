using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameObjectManager : MonoBehaviour {

	public bool destroyMe;
	GameObject temp;
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


		if (SceneManager.GetActiveScene ().name == "Main@2x") {
			DestroyImmediate (GameObject.Find("Stumps"));
			temp = Instantiate (Resources.Load ("Prefabs/Stumps")) as GameObject;
			temp.name = "Stumps";
		} else {
			DestroyImmediate (GameObject.Find("Stumps@1x"));
			temp = Instantiate (Resources.Load ("Prefabs/Stumps@1x")) as GameObject;
			temp.name = "Stumps@1x";
		}

		temp.transform.SetParent (GameObject.Find("Pitch").transform);
	}
}
