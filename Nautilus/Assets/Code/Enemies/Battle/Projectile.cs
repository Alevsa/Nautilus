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
	
	void OnCollisionEnter(Collision collision)
	{
		explode();
	}
	
	void Update()
	{
		Vector3 forwardForce = Vector3.forward * speed;
		body.AddRelativeForce (forwardForce);
	
		if (gameObject.transform.position.y < -20f)
		{
			Destroy(gameObject);
		}
		
	}
	void explode()
	{
		Destroy(gameObject);
		// insert particles here
	}
	
}
