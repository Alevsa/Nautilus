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
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				pointer = obj;
			}
		}
	}
	
	void Update () 
	{
		
		float distance = distanceFromPlayer();
		#region Get closer if too far away, move away when too close and orbit when in between.
		// Move toward target
		if (distance > maxOrbitRange)
		{
			pointer.transform.LookAt(target.transform);
			move(pointer.transform);
		}
		// Move away from target
		else if (distance < minOrbitRange)
		{
			pointer.transform.LookAt(target.transform);
			Transform opposite = pointer.transform;
			opposite.Rotate(180f * Vector3.up); 	
			move(opposite);
		}
		// Orbit
		else 
		{
			pointer.transform.LookAt(target.transform);
			Transform tangent = pointer.transform;
			tangent.Rotate(90f * Vector3.up); 
			move(tangent);	
		}
	}
	#endregion
	
	#region Moves the object
	void move(Transform target)
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
