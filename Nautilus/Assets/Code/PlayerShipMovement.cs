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
		Debug.Log (body.velocity);
	}

	void FixedUpdate() {
		Movement ();
	}

	public void Accelerate() {
//		if (body.velocity 
//		forwardForce = Vector3.forward * shipStats.Acceleration;
	}

	public void Break() {

	}

	public void Turn (int clockwise) {		
		turn = clockwise * shipStats.TurnRate;
	}

	void Movement () {
		body.AddRelativeForce (forwardForce);
		body.AddForceAtPosition (Vector3.right * turn , transform.position + Vector3.forward);
		turn = 0;
	}
}
