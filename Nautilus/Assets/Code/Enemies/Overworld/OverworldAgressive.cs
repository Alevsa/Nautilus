using UnityEngine;
using System.Collections;

public class OverworldAgressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// Assign pointer programatically
	// Create idle behavior

	#region Variables
	private GameObject focus;
	private GameObject player;
	public GameObject pointer;
	private RouteFinder routeFinder;
	float turnRate = 0.7f;
	public float maxSpeed = 10f;
	private float speed = 0f;
	public float visionRange = 50f;
	public float acceleration = 0.1f;

	// For the routefinder
	private GameObject[] waypoints;
	private int[] visited;
	#endregion

	#region Start method
	void Start () 
	{
		// This happens as the enemy will need to find the player when it spawns rather than having it preassigned in the inspector.
		// In the same vein will have to have the pointer assigned this way.
		player = GameObject.FindGameObjectWithTag("Player");
		routeFinder = new RouteFinder();

		// for the routefinder
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		visited = new int[waypoints.Length];
		for (int i = 0; i < visited.Length; i++)
		{
			visited[i] = 0;
		}
	}
	#endregion

	#region Update
	void Update () 
	{
		if (iCanSeePlayer())
		{
			moveToFocus();
		}
		else 
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
		gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		#endregion
	}
	#endregion

	IEnumerator moveToWaypoint()
	{
		return null;
	}

	#region Idle behavior, patrols the ship around
	void idle()
	{
		focus = returnNearestValidWaypoint(gameObject);
		moveToFocus();
	}
	#endregion

	#region Sees if the player is in range
	// It's not based on a cone or anything because generally people on ships will look in all directions, Though it would make
	// sense to implement a cone for a sea monster enemy idea I had. More on that later though.
	bool iCanSeePlayer()
	{
		if (Vector3.Magnitude(player.transform.position - gameObject.transform.position) <= visionRange)
		{
			focus = player;
			return true;
		}
		else 
		{
			return false;
		}
	}
	#endregion

	#region Finds next waypoint
	public GameObject returnNearestValidWaypoint(GameObject origin)
	{
		int closest = 0;
		GameObject min = waypoints[0];
		for (int i = 1; i<waypoints.Length; i++)
		{
			if (!Physics.Raycast(origin.transform.position, waypoints[i].transform.position))
			{
				float distance = Vector3.Magnitude(origin.transform.position - waypoints[i].transform.position);
				if (distance < closest)
				{
					if (visited[i] <= visited[closest])
					{
						closest = i;
					}
				}
			}
		}
		visited[closest] += 1;
		return waypoints[closest];
	}
	#endregion

}
