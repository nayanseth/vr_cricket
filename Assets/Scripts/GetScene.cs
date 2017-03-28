using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GetScene : MonoBehaviour {

	
	public void SetScene(GameObject target) {
		if (target.name == "REAL PITCH") {
			SceneManager.LoadScene ("Main@1x");
		} else if(target.name == "@2x PITCH") {
			SceneManager.LoadScene ("Main@2x");
		}
	}
}
