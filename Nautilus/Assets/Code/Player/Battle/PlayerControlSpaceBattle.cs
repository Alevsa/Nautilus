using UnityEngine;
using System.Collections;

public class PlayerControlSpaceBattle : MonoBehaviour 
{
	
	//Ship to be controlled
	public GameObject Ship;
	private PlayerMovementSpaceBattle handlerMovement;
	//private SmoothFollow m_smoothFollow;
	private CameraControlNew m_CamControl;
	private WeaponController m_WeapControl;
	
	private bool inMenu = false;
	private bool shipAlive = true;
	
	private float m_RotDamping;
	
	// Use this for initialization
	void Start () 
	{
		Ship = GameObject.FindGameObjectWithTag("PlayerBattle");
		handlerMovement = Ship.GetComponent<PlayerMovementSpaceBattle>();
		m_CamControl = GameObject.Find("Main Camera").GetComponent<CameraControlNew>();
		m_WeapControl = Ship.GetComponent<WeaponController>();
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
	void InGameInput() 
	{
		
		if (Input.GetButtonDown ("Accelerate"))
			handlerMovement.accelerate();
		else if (Input.GetButtonDown ("Brake"))
			handlerMovement.StartCoroutine("Brake");
		else 
			handlerMovement.decelerate ();
		
		rotateShip();		
	}
	
	void rotateShip()
	{
		handlerMovement.handleMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
