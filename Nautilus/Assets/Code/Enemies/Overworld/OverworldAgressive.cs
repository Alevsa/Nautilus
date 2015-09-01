using UnityEngine;
using System.Collections;

public class OverworldAgressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// Assign pointer programatically
	// Create idle behavior

	#region Variables
	private bool spottedFocus = false;
	private GameObject focus;
	public GameObject pointer;
	public float turnRate = 0.7f;
	public float maxSpeed = 10f;
	private float speed = 0f;
	public float visionRange = 50f;
	public float acceleration = 0.1f;
	#endregion

	#region Start method
	void Start () 
	{
		// This happens as the enemy will need to find the player when it spawns rather than having it preassigned in the inspector.
		// In the same vein will have to have the pointer assigned this way.
		focus = GameObject.FindGameObjectWithTag("Player");
	}
	#endregion

	#region Update
	void Update () 
	{
		if (iCanSeeMyFocus())
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

	#region Idle behavior, will likely be similar to neutral behavior which is unimplemented
	void idle()
	{

	}
	#endregion

	#region Sees if the focus is in range
	// It's not based on a cone or anything because generally people on ships will look in all directions, Though it would make
	// sense to implement a cone for a sea monster enemy idea I had. More on that later though.
	bool iCanSeeMyFocus()
	{
		if (Vector3.Magnitude(focus.transform.position - gameObject.transform.position) <= visionRange)
		{
			return true;
		}
		else 
		{
			return false;
		}
	}
	#endregion
}
