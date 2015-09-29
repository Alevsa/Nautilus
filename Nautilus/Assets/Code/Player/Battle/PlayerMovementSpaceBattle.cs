using UnityEngine;
using System.Collections;

public class PlayerMovementSpaceBattle : MonoBehaviour 
{
	private PlayerStatsSpaceBattle stats;
	private Rigidbody body;
	private GameObject playerCam;
	private float speed;
	private int inverted = 1;
	[HideInInspector]
	public Vector3 newPosition;
	
	void Start()
	{
		playerCam = GameObject.FindGameObjectWithTag("MainCamera");
		stats = GetComponent<PlayerStatsSpaceBattle> ();
		body = GetComponent<Rigidbody> ();
		if (stats.isInverted)
		{
			inverted = 1;
		}
		else 
		{
			inverted = -1;
		}
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
	
	public void roll(float direction)
	{
		transform.Rotate(new Vector3(0f, 0f, direction * stats.rollSensitivity));
	}
	
	// Don't complain, it's a prototype.
	public void handleMouse(float x, float y)
	{
		transform.Rotate(inverted * stats.sensitivity * y, stats.sensitivity * x, 0f);
	}
}
