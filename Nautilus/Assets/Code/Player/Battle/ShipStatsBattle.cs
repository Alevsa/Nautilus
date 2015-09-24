using UnityEngine;
using System.Collections;

public class ShipStatsBattle : MonoBehaviour 
{
	public int MaxSpeed = 15;
	public float Acceleration = 1f;
	public float TurnRate = 1f;
	public float Health = 1f;
	public float rightingForce = 1f;
	
	public float deathTime = 5f;
	public float deathForce = 9.81f;
	
	void OnCollisionEnter(Collision collision)
	{	
		if (collision.gameObject.tag != "Terrain")
		{
			Health -= Vector3.Magnitude(collision.rigidbody.velocity*collision.rigidbody.mass);
		}
	}
	
	void Update()
	{
		if (Health <= 0f)
		{
			StartCoroutine("die");
		}
	}
	
	// This is fucked
	public IEnumerator die()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		float deathForcePerSecond = deathForce/deathTime;
		float turnPerSecond = TurnRate/deathTime;
		float accelerationPerSecond = Acceleration/deathTime;
		deathForce = 0f;
		
		while (deathTime > 0f)
		{
			Acceleration -= Time.deltaTime*accelerationPerSecond;
			TurnRate -= Time.deltaTime*turnPerSecond;
			deathForce += deathForcePerSecond*Time.deltaTime; 
			body.AddForce(deathForce*Vector3.down);
			yield return null;
		}
	}
}
