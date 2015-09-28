using UnityEngine;
using System.Collections;

public class PlayerMovementSpaceBattle : MonoBehaviour 
{
	private PlayerStatsSpaceBattle stats;
	private Rigidbody body;
	private GameObject playerCam;
	private float speed;
	
	
	void Start()
	{
		playerCam = GameObject.FindGameObjectsWithTag("MainCamera");
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
		transform.rotation = Quaternion.RotateTowards(transform.rotation, GetComponent<Camera>().transform.rotation, stats.turnRate);
	}
	
	void acceletate()
	{
		if (speed < stats.maxSpeed)
		{
			speed += stats.acceleration;
		}
	}
	
	
	
}
