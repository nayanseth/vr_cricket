using UnityEngine;
using System.Collections;
using System;

public class Laser : MonoBehaviour
{

	LineRenderer line;
	public GameObject target;
	SteamVR_Controller.Device device;
	GetName character;
	// Use this for initialization
	void Start()
	{

		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = true;
		line.useWorldSpace = false;
		line.SetVertexCount(3);
		line.SetColors(Color.cyan, Color.cyan);
		line.SetWidth(0.01f, 0.01f);
		character = GameObject.Find ("Player Manager").GetComponent<GetName> ();
	}

	// Update is called once per frame
	void Update()
	{

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			//print("Collider hit: " + hit.collider);
			if (hit.collider)
			{
				target = hit.transform.gameObject;
				line.SetPosition(1, new Vector3(transform.rotation.x, 0, hit.distance));
				try {
					device = this.gameObject.GetComponent<ControllerManager> ().device;
					if(device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
						character.GetCharacter(hit.collider.gameObject);
						device.TriggerHapticPulse(3000);
					}

				} catch(NullReferenceException e) {
					print ("Trying to connect to controller");
				}


			}
		}
		else
		{
			//print("No Collider");
			line.SetPosition(1, new Vector3(transform.rotation.x, 0, 10000));
		}
	}


}