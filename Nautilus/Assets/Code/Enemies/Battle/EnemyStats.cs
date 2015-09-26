using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour 
{
	public float health= 15f;
	private GameObject target;
	private GameObject pointer;
	private Rigidbody body;
	public bool dead = false;
	
	public float deathForce = 9.81f;
	public float deathTime = 10f;
	public float rightingForce = 98.1f;
	public float turnRate = 1f;
	public float speed = 7f;
	
	
	void OnCollisionEnter(Collision collision)
	{	
		if (collision.gameObject.tag != "Terrain")
		{
			health -= Vector3.Magnitude(collision.rigidbody.velocity*collision.rigidbody.mass);
		}
	}
	
	void Update()
	{
		if (health <= 0f && !dead)
		{
			dead = true;
			rightingForce = 0f;
			StartCoroutine("die");
		}
	}
	
	// This is fucked
	public IEnumerator die()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		float deathForcePerSecond = deathForce/deathTime;
		deathForce = 0f;
		 
		while (deathTime > 0f)
		{
			turnRate = 0f;
			rightingForce = 0f;
			speed = 0f;
			
			deathForce += deathForcePerSecond*Time.deltaTime; 
			body.AddForce(deathForce*Vector3.down);
			yield return null;
		}
	}
}
