using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

	LineRenderer line;
	public GameObject target;

	// Use this for initialization
	void Start()
	{

		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = true;
		line.useWorldSpace = false;
		line.SetVertexCount(3);
		line.SetColors(Color.cyan, Color.cyan);
		line.SetWidth(0.01f, 0.01f);
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
				//print("Cube found at " + hit.point + "with normal " + hit.normal);
				line.SetPosition(1, new Vector3(transform.rotation.x, 0, hit.distance));
			}
		}
		else
		{
			//print("No Collider");
			line.SetPosition(1, new Vector3(transform.rotation.x, 0, 10000));
		}
	}


}