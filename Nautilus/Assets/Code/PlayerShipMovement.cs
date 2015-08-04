using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour {

	public ShipStats shipStats;

	private int speedRank;
	private int maxSpeedRank = 4;
	private int prevSpeedRank = 0;
	private float turn;

	// Use this for initialization
	void Start () {
		shipStats = GetComponent<ShipStats> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		Movement ();
	}

	public void Accelerate() {
		if (speedRank < maxSpeedRank)
			speedRank++;

		Debug.Log (speedRank);
	}

	public void Decelerate() {
		if (speedRank > 0)
			speedRank--;

		Debug.Log (speedRank);
	}

	public void Break(bool br) {
		if (br) 
		{
			if (speedRank != 0)
				prevSpeedRank = speedRank;
			speedRank = 0;
		}
		else
			speedRank = prevSpeedRank;

		Debug.Log (speedRank);

	}

	public void Turn (int clockwise) {
		
		turn = clockwise * shipStats.TurnRate;
	}

	void Movement () {
		int speed = shipStats.Speed;
		gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * speedRank * 0.25F * speed);
		gameObject.GetComponent<Rigidbody> ().AddForceAtPosition (Vector3.right * turn / (speed + 1), transform.position + Vector3.forward);
		turn = 0;
	}
}
