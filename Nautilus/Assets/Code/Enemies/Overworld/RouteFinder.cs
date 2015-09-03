using UnityEngine;
using System.Collections;

public class RouteFinder : MonoBehaviour 
{

	private GameObject[] waypoints;
	private int[] visited;
	// Use this for initialization
	void Start () 
	{
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		visited = new int[waypoints.Length];
		for (int i = 0; i < visited.Length; i++)
		{
			visited[i] = 0;
		}
	}
	
	#region Returns the closest waypoint the ship can move to.
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
