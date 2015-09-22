using UnityEngine;
using System.Collections;

public class Ram : MonoBehaviour {

	public GameObject focus;
	public float maxSpeed;
	private float distance;
	public float chargeDistance;
	
	void Start () 
	{
		shouldICharge();
	}

	void charge()
	{
		// Charge toward focus for a while
		shouldICharge();
	}

	IEnumerable getIntoPosition()
	{
		// Get into position
		while (distance < chargeDistance)
		{
			// move away
			yield return null;
		}
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
