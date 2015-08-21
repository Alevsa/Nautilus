using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour 
{
	// Very basic for now, might get more complex later.
	// in minutes
	public float _lengthOfDay = 2f;
	private float lengthOfDay = 120f;
	void Start()
	{
		lengthOfDay = _lengthOfDay * 60;
	}
	void Update () 
	{
		gameObject.transform.Rotate((360f/lengthOfDay)*Vector3.left*Time.deltaTime);
	}
}
