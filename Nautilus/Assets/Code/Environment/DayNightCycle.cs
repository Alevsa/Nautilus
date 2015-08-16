using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour 
{
	// Very basic for now, might get more complex later. To account for light changing colour through the cycle.
	public float timeflow = 1f;
	void Update () 
	{
		gameObject.transform.Rotate(timeflow*Vector3.down*Time.deltaTime);
	}
}
