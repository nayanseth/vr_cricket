using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath : MonoBehaviour {

	int score;
	public AudioClip shot;
	AudioSource audio;
	BallLauncher controller;
	Vector3 velocity;
	VariableManager vm;
	Rigidbody batRigidBody;
	TextManager tm;

	void Start() {
		audio = GameObject.Find ("Managers").GetComponent<AudioSource> ();
		controller = GameObject.Find ("Managers").GetComponent<BallLauncher> ();
		batRigidBody = this.gameObject.GetComponent<Rigidbody> ();
		vm = GameObject.Find ("Managers").GetComponent<VariableManager> ();
		tm = GameObject.Find ("Managers").GetComponent<TextManager> ();
	}

	void OnCollisionEnter(Collision other){
		audio.clip = shot;

		if(other.gameObject.tag=="Ball") {


			audio.Play ();

		
			vm.SetBatHit (true);


			ContactPoint contact = other.contacts[0];
			GameObject temp = Instantiate (Resources.Load ("Prefabs/Transparent Ball"), contact.point, new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
			temp.name = "Transparent Ball";
			temp.transform.SetParent (GameObject.Find ("Cricket Bat Right").transform);

			controller.hapticFeedbackFlag = true;
			velocity = controller.velocity;
			//batRigidBody.MovePosition (batRigidBody.position + transform.rotation * new Vector3 (velocity.x, velocity.y, velocity.z));

			other.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(velocity.x,velocity.y,velocity.z), ForceMode.Impulse);

			score = vm.GetScoreCount();
			vm.SetScoreCount (++score);
			tm.SetScoreText (score.ToString ());
			tm.SetNRRText(vm.GetNRR().ToString());
		}

	}
}
