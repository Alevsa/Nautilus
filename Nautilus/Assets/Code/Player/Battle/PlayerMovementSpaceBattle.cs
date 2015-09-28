using UnityEngine;
using System.Collections;

public class PlayerMovementSpaceBattle : MonoBehaviour 
{
	private PlayerStatsSpaceBattle stats;
	private Rigidbody body;
	private GameObject playerCam;
	private float speed;
	[HideInInspector]
	public Vector3 newPosition;
	
	void Start()
	{
		playerCam = GameObject.FindGameObjectWithTag("MainCamera");
		stats = GetComponent<PlayerStatsSpaceBattle> ();
		body = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{
		movement();
	}
	
	void movement()
	{
		body.AddRelativeForce(Vector3.forward * speed);
		
		// Camera should follow the players movement not vice versa
		// transform.rotation = Quaternion.RotateTowards(transform.rotation, playerCam.transform.rotation, stats.turnRate);
	}
	
	public void accelerate()
	{
		if (speed < stats.maxSpeed)
		{
			speed += stats.acceleration;
		}
	}
	
	public void decelerate()
	{
		if (speed > 0f)
		{
			speed -= stats.acceleration;
		}
	} 
	
	// Don't complain, it's a prototype.
	public void handleMouse(float x, float y)
	{
		transform.Rotate(-1f * stats.sensitivity * y, stats.sensitivity * x, 0f);
	}
}
