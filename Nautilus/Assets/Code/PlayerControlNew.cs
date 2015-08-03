﻿using UnityEngine;
using System.Collections;

//Handles player input

public class PlayerControlNew : MonoBehaviour {

	//Ship to be controlled
	public GameObject Ship;

	private bool inMenu = false;
	private bool shipAlive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inMenu)
			MenuInput ();
		else if (shipAlive)
			InGameInput ();
	}

	void MenuInput() {

	}

	//In-game handling
	void InGameInput() {

		PlayerShipMovement handlerMovement = Ship.GetComponent<PlayerShipMovement> ();

		if (Input.GetButtonDown ("Accelerate"))
			handlerMovement.Accelerate ();

		if (Input.GetButtonDown ("Decelerate"))
			handlerMovement.Decelerate ();

		if (Input.GetButton ("Break"))
			handlerMovement.Break (true);
		else if (Input.GetButtonUp("Break"))
			handlerMovement.Break (false);

		handlerMovement.Turn ((int)Input.GetAxisRaw("Turn"));
	}
	
}
