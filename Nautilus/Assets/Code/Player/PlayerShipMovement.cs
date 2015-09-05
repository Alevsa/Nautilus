using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour {

	public ShipStats shipStats;

	private Rigidbody body;
	private Vector3 forwardForce;
	private float turn;

	// Use this for initialization
	void Start () {
		shipStats = GetComponent<ShipStats> ();
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (body.velocity.magnitude);
	}

	void FixedUpdate() {
		Movement ();
	}

	public void Accelerate() 
	{
		if (body.velocity.magnitude < shipStats.MaxSpeed)
			forwardForce = Vector3.forward * shipStats.Acceleration;
		else
			forwardForce = Vector3.zero;
	}

	public void Brake() 
	{
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
		body.AddRelativeForce (forwardForce);
		//transform.Rotate(Vector2.up * turn);
		body.AddForceAtPosition (Vector3.right * turn, transform.position + Vector3.forward);
		turn = 0;
	}
}
