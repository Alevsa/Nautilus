using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour 
{
	// Very basic for now, might get more complex later.
	public float timeSpeed = 1f;
	void start()
	{
	}
	void Update () 
	{
		gameObject.transform.Rotate(timeSpeed*Vector3.left*Time.deltaTime);
	}
}
