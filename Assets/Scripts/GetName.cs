using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetName : MonoBehaviour {

	Text nameText, charText;
	bool capsLock, addText;
	string str;
	PlayerManager pm;

	void Start() {
		nameText = GameObject.Find ("Name").GetComponent<Text> ();
		capsLock = false;
		addText = true;
		pm = GameObject.Find ("Player Manager").GetComponent<PlayerManager> ();
	}

	public void GetCharacter(GameObject character){
		charText = character.GetComponentInChildren<Text> ();
		if (charText.text == "↑") {
			capsLock = !capsLock;
			if (capsLock) {
				character.GetComponent<Image> ().color = Color.cyan;
				//charText.color = Color.white;
				addText = false;
			} else {
				character.GetComponent<Image> ().color = Color.white;
				//charText.color = Color.black;
			}
			addText = false;
		} else if (charText.text == "DEL") {
			if (nameText.text.Length != 0) {
				nameText.text = nameText.text.Substring (0, nameText.text.Length - 1);
			}
			addText = false;
		}else if(charText.text == "CONTINUE") {
			pm.SetName (nameText.text);
			addText = false;
			SceneManager.LoadScene ("Bowling Info");
		} else {
			addText = true;
		}
		if (capsLock) {
			str = charText.text.ToUpper ();
		} else {
			str = charText.text.ToLower ();
		}

		if (addText) {
			str = str.Trim ();
			nameText.text += str;
		}
	}



}
