using UnityEngine;
using System.Collections;

public class CelestialOrbit : MonoBehaviour 
{
	public GameObject focus;
	private GameObject pointer;
	private float distance;
	private Rigidbody body;
	public float speed = 1f;
	
	void Start()
	{
		body = gameObject.GetComponent<Rigidbody>();
		distance = Vector3.Distance(transform.position, focus.transform.position);		
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
	void Update () 
	{
		getDirection();
		move();
	
	}
	#region Gets the direction of movement
	void getDirection()
	{
		pointer.transform.LookAt(focus.transform);
		pointer.transform.Rotate(new Vector3(0f, 90f, 0f)) ;
		
	}
	#endregion	
	#region Moves the object
	void move()
	{
		Vector3 forwardForce = pointer.transform.forward * speed;
		body.AddRelativeForce (forwardForce);
	}
	#endregion


}
