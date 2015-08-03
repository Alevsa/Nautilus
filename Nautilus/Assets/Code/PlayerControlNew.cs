using UnityEngine;
using System.Collections;

//Handles player input

public class PlayerControlNew : MonoBehaviour {

	//Ship to be controlled
	public GameObject Ship;
    private PlayerShipMovement handlerMovement;
    private CameraController camControl;

	private bool inMenu = false;
	private bool shipAlive = true;

	// Use this for initialization
	void Start () 
    {
       handlerMovement = Ship.GetComponent<PlayerShipMovement>();
       camControl = GameObject.Find("Main Camera").GetComponent<CameraController>();
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

		if (Input.GetButtonDown ("Accelerate"))
			handlerMovement.Accelerate ();

		if (Input.GetButtonDown ("Decelerate"))
			handlerMovement.Decelerate ();

		if (Input.GetButton ("Break"))
			handlerMovement.Break (true);
		else if (Input.GetButtonUp("Break"))
			handlerMovement.Break (false);

		handlerMovement.Turn ((int)Input.GetAxisRaw("Turn"));

        float h = Input.GetAxis("Mouse ScrollWheel");
        camControl.AdjustZoom(h);

        if(Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            camControl.AdjustRotation(x);
        }
	}
	
}
