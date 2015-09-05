using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

//Handles player input

public class PlayerControlNew : MonoBehaviour {

	//Ship to be controlled
	public GameObject Ship;
    private PlayerShipMovement handlerMovement;
    //private SmoothFollow m_smoothFollow;
    private CameraControlNew m_CamControl;
    private WeaponController m_WeapControl;

	private bool inMenu = false;
	private bool shipAlive = true;

    private float m_RotDamping;

	// Use this for initialization
	void Start () 
    {
       handlerMovement = Ship.GetComponent<PlayerShipMovement>();
       m_CamControl = GameObject.Find("Main Camera").GetComponent<CameraControlNew>();
       m_WeapControl = Ship.GetComponent<WeaponController>();

      // m_smoothFollow = GameObject.Find("Main Camera").GetComponent<SmoothFollow>();
      // m_RotDamping = m_smoothFollow.RotationDamping;
	}
	
	// Update is called once per frame
	void Update () {
		if (inMenu)
			MenuInput ();
		else if (shipAlive)
			InGameInput ();
			CameraControls();
	}

	void MenuInput() {

	}

	//In-game handling
	void InGameInput() 
    {

		if (Input.GetButtonDown ("Accelerate"))
			handlerMovement.StartCoroutine("Accelerate");
		else if (Input.GetButton ("Brake"))
			handlerMovement.StartCoroutine("Brake");
		else 
			handlerMovement.Decelerate ();

		handlerMovement.Turn ((int)Input.GetAxisRaw("Turn"));

        if (Input.GetButtonDown("Fire1"))
            m_WeapControl.Fire(0);

        if (Input.GetButtonDown("Fire2"))
            m_WeapControl.Fire(1);
		
	}

    private void CameraControls()
    {
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			m_CamControl.ChangeZoom (Mathf.CeilToInt (Input.GetAxis ("Mouse ScrollWheel")));

        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
			float y = Input.GetAxis("Mouse Y");
            
			m_CamControl.HandleMouseX(x);
			m_CamControl.HandleMouseY(y);
        }

        //else
           // m_smoothFollow.RotationDamping = m_RotDamping;
    }
	
}
