using UnityEngine;
using System.Collections;

public class CelestialOrbit : MonoBehaviour 
{
	public GameObject focus;
	private GameObject pointer;
	private float orbitalRadius;
	private Rigidbody body;
	public float period = 10f;
	private float speed;
	
	void Start()
	{
		body = gameObject.GetComponent<Rigidbody>();
		orbitalRadius = Vector3.Distance(transform.position, focus.transform.position);
		speed = 2f * Mathf.PI * orbitalRadius / period;		
		#region Gets the pointer
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				pointer = obj;
			}
		}
		#endregion
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		move();
	
	}
	#region This whole thing is kind of disjointed cause I realised different things were required at different times. 

	void move()
	{
		centripetalForce();
		velocity();
		
	}
	
	// Applies centripetal force
	void centripetalForce()
	{
		pointer.transform.LookAt(focus.transform);
		Vector3 forwardForce = pointer.transform.forward * Mathf.Pow(speed, 2) * body.mass / orbitalRadius;
		body.AddRelativeForce (forwardForce);
	}
	// force in the direction of motion
	void velocity()
	{
		
		pointer.transform.LookAt(focus.transform);
		pointer.transform.Rotate(new Vector3(0f, 90f, 0f)) ;
		Vector3 forwardForce = pointer.transform.forward * speed * body.mass;
		body.AddRelativeForce (forwardForce);
	}
	#endregion


}
