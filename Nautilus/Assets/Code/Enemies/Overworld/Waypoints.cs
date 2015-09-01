using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour 
{
	private GameObject[] waypoints;
	// Use this for initialization
	void Start () 
	{
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}

	#region Returns the closest waypoint the ship can move to.
	public GameObject returnNearestValidWaypoint(GameObject origin)
	{
		int closest = 0;
		GameObject min = waypoints[0];
		for (int i = 1; i<waypoints.Length; i++)
		{
			if (!Physics.Raycast(origin.transform.position, waypoints[i].transform.position, Mathf.Infinity))
			{
				float distance = Vector3.Magnitude(origin.transform.position - waypoints[i].transform.position);
				if (distance < closest)
				{
					closest = i;
				}
			}
		}
		return waypoints[closest];
	}
	#endregion
}
