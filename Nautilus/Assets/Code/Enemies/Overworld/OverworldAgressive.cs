using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class OverworldAgressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// ? ? ?
	
	#region Variables
	private GameObject focus;
	private GameObject player;
	private GameObject pointer;
	public float turnRate = 0.7f;
	public float maxSpeed = 10f;
	private float speed = 0f;
	public float visionRange = 50f;
	public float acceleration = 0.1f;
	private int excluding;
	private Rigidbody body;
	private bool inPursuit = false;
	private float y = 0;
	private float stuckTime = 3f*60f;

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
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				pointer = obj;
			}
		}

		// for the routefinder
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		visited = new int[waypoints.Length];
		for (int i = 0; i < visited.Length; i++)
		{
			visited[i] = 1;
		}
		
		fadeIn();
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

	#region Move toward focus/waypoint
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
	

	public IEnumerator moveToWaypoint()
	{
		while (true)
		{
			moveToFocus();
			yield return null;
		}
	}
	#endregion
	
	#region Handles collision and arriving at waypoints
	void OnCollisionEnter(Collision collision)
	{
		// Collisions are the only event that can screw up the Y level so this code is here to fix that.
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
		StopCoroutine("moveToWaypoint");
		bored = true;
	}
	
	void OnTriggerEnter(Collider other)
	{
		StopCoroutine("moveToWaypoint");
		bored = true;
	}
	#endregion
	
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
	
	
	IEnumerable fadeIn()
	{
		for (float i = 0; i<3f; i+=Time.deltaTime)
		{
			yield return null;		
		}
	}
	
	
	#region Despawn if stuck, this is literally pointless right now 
	void OnCollisionStay(Collision collision)
	{
		stuckTime-=Time.deltaTime;
		if (stuckTime <= 0)
		{
			despawn();
		}
	}
	
	
	void despawn()
	{
		Destroy(gameObject);
	}
	#endregion

}
