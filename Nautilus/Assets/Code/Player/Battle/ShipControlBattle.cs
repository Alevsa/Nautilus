using UnityEngine;
using System.Collections;

public class ShipControlBattle : MonoBehaviour 
{
	public ShipStatsBattle shipStats;
	
	private Rigidbody body;
	private float speed;
	private Vector3 forwardForce;
	private float turn;
	
	// Use this for initialization
	void Start () 
	{
		shipStats = GetComponent<ShipStatsBattle> ();
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//		Debug.Log (body.velocity.magnitude);
	}
	
	void FixedUpdate() {
		Movement ();
	}
	
	public IEnumerator Accelerate() 
	{
		while (speed < shipStats.MaxSpeed)
		{
			speed += shipStats.Acceleration;
			yield return null;
		}
		
		
		/*
		if (body.velocity.magnitude < shipStats.MaxSpeed)
			forwardForce = Vector3.forward * shipStats.Acceleration;
		else
			forwardForce = Vector3.zero;
	*/
	}
	
	public IEnumerator Brake() 
	{
		while (speed > 0)
		{
			speed -= shipStats.Acceleration;
			yield return null;
		}
		
		//	if (body.velocity.magnitude > shipStats.Acceleration / body.mass)
		//			forwardForce = Vector3.back * shipStats.Acceleration;
	}
	
	public void Decelerate () {
		forwardForce = Vector3.zero;
	}
	
	public void Turn (int clockwise) {		
		turn = clockwise * shipStats.TurnRate;
	}
	
	void Movement () {
		//	gameObject.transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
		forwardForce = Vector3.forward * speed;
		body.AddRelativeForce (forwardForce);
		body.AddForceAtPosition (Vector3.right * turn, transform.position + Vector3.forward);
		turn = 0;
	}
}
