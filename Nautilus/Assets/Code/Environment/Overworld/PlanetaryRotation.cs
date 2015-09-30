using UnityEngine;
using System.Collections;

public class PlanetaryRotation : MonoBehaviour
{
	public float dayLength = 60f;
	private float degreesPerSecond = 360f/60f;
	
	void Start()
	{
		degreesPerSecond = 360f / dayLength;
	}
	
	void FixedUpdate () 
	{
		gameObject.transform.Rotate(new Vector3(0f,degreesPerSecond,0f));
	}
}
