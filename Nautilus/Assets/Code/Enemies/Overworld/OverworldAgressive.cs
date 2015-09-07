using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class OverworldAgressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// Assign pointer programatically
	
	#region Variables
	private GameObject focus;
	private GameObject player;
	public GameObject pointer;
	public float turnRate = 0.7f;
	public float maxSpeed = 10f;
	private float speed = 0f;
	public float visionRange = 50f;
	public float acceleration = 0.1f;
	private int excluding;
	private Rigidbody body;
	private bool inPursuit = false;

	// For the routefinder
	private GameObject[] waypoints;
	private int[] visited;
	private bool bored = true;
	#endregion

	#region Start method
	void Start () 
	{
		// This happens as the enemy will need to find the player when it spawns rather than having it preassigned in the inspector.
		// In the same vein will have to have the pointer assigned this way.
		player = GameObject.FindGameObjectWithTag("Player");
		body = GetComponent<Rigidbody> ();

		// for the routefinder
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		visited = new int[waypoints.Length];
		for (int i = 0; i < visited.Length; i++)
		{
			visited[i] = 1;
		}
	}
	#endregion

	#region Update
	void Update () 
	{
		if (inPursuit)
		{
			bored = true;
		}
		if (iCanSeePlayer())
		{
			bored = false;
			inPursuit = true;
			focus = player;
			StopCoroutine("moveToWaypoint");
			moveToFocus();
		}
		
		else if (bored)
		{
			idle();
		}

	}
	#endregion

	#region Move toward focus
	void moveToFocus()
	{
		#region Accelerates
		if (speed < maxSpeed)
		{
			speed += acceleration;
		}
		#endregion
		#region Rotates the enemy to face the player
		pointer.transform.LookAt(focus.transform);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, pointer.transform.rotation, turnRate);
		//gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		Vector3 forwardForce = Vector3.forward * speed;
		body.AddRelativeForce (forwardForce);
		#endregion
	}
	#endregion

	public IEnumerator moveToWaypoint()
	{
		while (true)
		{
			moveToFocus();
			yield return null;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		StopCoroutine("moveToWaypoint");
		bored = true;
	}
	
	#region Idle behavior, patrols the ship around
	void idle()
	{
		focus = returnNearestValidWaypoint(gameObject);
		bored = false;
		StartCoroutine("moveToWaypoint");
	}
	#endregion

	#region Sees if the player is in range
	// It's not based on a cone or anything because generally people on ships will look in all directions, Though it would make
	// sense to implement a cone for a sea monster enemy idea I had. More on that later though.
	bool iCanSeePlayer()
	{
		if (Vector3.Magnitude(player.transform.position - gameObject.transform.position) <= visionRange)
		{
			return true;
		}
		else 
		{
			inPursuit = false;
			return false;
		}
	}
	#endregion

	#region Finds next waypoint
	public GameObject returnNearestValidWaypoint(GameObject origin)
	{
		float[] waypointDistance = new float[waypoints.Length];
		for (int i = 0; i < waypoints.Length; i++) 
		{
			waypointDistance[i] = Vector3.Magnitude(origin.transform.position - waypoints[i].transform.position)*visited[i];
		}
		int minIndex = 0;
		float minDistance = Mathf.Infinity;
		for (int i = 0; i<waypointDistance.Length; i++)
		{
			if (waypointDistance[i] < minDistance && i != excluding)
			{
				minDistance = waypointDistance[i];
				minIndex = i;
			}
		}
		excluding = minIndex;
		visited[minIndex] += 2;
		return waypoints[minIndex];

	}
	#endregion

}
