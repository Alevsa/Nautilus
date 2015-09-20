using UnityEngine;
using System.Collections;

public class Ram : MonoBehaviour {

	public GameObject focus;
	public float maxSpeed;
	void Start () 
	{
		shouldICharge();
	}

	void charge()
	{
		// Charge toward focus for a while
		shouldICharge();
	}

	void getIntoPosition()
	{
		// Get into position
		charge();
	}

	void shouldICharge()
	{
		// if aligned toward player and far away enough
		if (true)
		{
			charge();
		}
		else 
		{
			getIntoPosition();
		}
	}

}
