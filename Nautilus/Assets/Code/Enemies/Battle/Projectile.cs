using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	private Rigidbody body;
	public float speed = 20f;
	public float lifeTime;
	
	void Start () 
	{	
		body = GetComponent<Rigidbody> ();
	}
	
	void Update()
	{
		Vector3 forwardForce = Vector3.forward * speed;
		body.AddRelativeForce (forwardForce);
	
		if (gameObject.transform.position.y < -200f)
		{
			Destroy(gameObject);
		}
		
	}
	
}
