using UnityEngine;
using System.Collections;

public class FloatingRock : MonoBehaviour {

	// Just a really basic script that makes rocks drift a little.
	public float speed = 1;
	private Vector3 drift = new Vector3(0.2F, 0, 0);
	void start ()
	{
		drift.x = Random.Range (-1, 1);
		drift.y = Random.Range(-1, 1);
		drift.z =  Random.Range(-1, 1);
	}

	void Update () 
	{
		gameObject.transform.Rotate (speed * drift * Time.deltaTime);
	}
}
