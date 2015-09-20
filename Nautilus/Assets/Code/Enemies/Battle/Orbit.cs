using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour 
{
	private GameObject target;
	private GameObject pointer;
	private Rigidbody body;
	public float turnRate = 1f;
	public float maxOrbitRange = 250f;
	public float minOrbitRange = 200f;
	public float speed = 7f;
	
	void Start () 
	{
		body = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag("PlayerBattle");
		pointer = gameObject.transform.GetChild(0).gameObject;
	}
	
	void Update () 
	{
		
		float distance = distanceFromPlayer();
		if (distance > maxOrbitRange)
		{
			pointer.transform.LookAt(target.transform);
			alterDistance(pointer.transform);
		}
		else if (distance < minOrbitRange)
		{
			// Needs to look away from the target
			pointer.transform.LookAt(target.transform);
			Transform opposite = pointer.transform;
			opposite.Rotate(180f * Vector3.up); 	
			alterDistance(opposite);
		}
		else 
		{
			rotateAround();	
		}
	}
	
	#region Orbit
	void rotateAround()
	{
		transform.RotateAround(target.transform.position, Vector3.up, speed*Time.deltaTime);
	}
	#endregion
	#region Get close enough to orbit
	void alterDistance(Transform target)
	{
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, target.rotation, turnRate);
		Vector3 forwardForce = Vector3.forward * speed;
		body.AddRelativeForce (forwardForce);
	}
	#endregion
	
	#region Distance calculation
	float distanceFromPlayer()
	{
		return Vector3.Distance(target.transform.position, gameObject.transform.position);
	}
	#endregion
}
