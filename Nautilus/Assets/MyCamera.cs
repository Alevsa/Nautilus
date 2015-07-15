using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour
{

	private float x;
	private float z;
	public float zoom = 50f;
	public GameObject focus;

	// The camera is just fixed to the player.
	// Update is called once per frame
	void Update () 
	{
		x = focus.transform.position.x;
		z = focus.transform.position.z;
		gameObject.transform.position = new Vector3 (x, zoom, z);
	}
}
