using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPath : MonoBehaviour {

	Text scoreText;
	int score;
	public AudioClip shot;
	AudioSource audio;
	BallLauncher controller;
	Vector3 velocity;

	Rigidbody batRigidBody;

	void Start() {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		controller = GameObject.Find ("Controller (right)").GetComponent<BallLauncher> ();
		batRigidBody = this.gameObject.GetComponent<Rigidbody> ();
		scoreText = GameObject.Find ("Score").GetComponent<Text>();
	}

	void OnCollisionEnter(Collision other){
		audio.clip = shot;

		if(other.gameObject.tag=="Ball") {

			score = ++GameObject.Find ("Managers").GetComponent<ScoreManager> ().score;
			scoreText.text = score.ToString (); 


			audio.Play ();
			controller.flag = true;
			velocity = controller.velocity;
			//batRigidBody.MovePosition (batRigidBody.position + transform.rotation * new Vector3 (velocity.x, velocity.y, velocity.z));

			other.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(velocity.x,velocity.y,velocity.z), ForceMode.Impulse);

		}

	}
}
