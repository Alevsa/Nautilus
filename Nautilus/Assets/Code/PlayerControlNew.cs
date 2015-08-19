using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

//Handles player input

public class PlayerControlNew : MonoBehaviour {

	//Ship to be controlled
	public GameObject Ship;
    private PlayerShipMovement handlerMovement;
    private SmoothFollow m_smoothFollow;
    private CameraController m_CamControl;
    private WeaponController m_WeapControl;

	private bool inMenu = false;
	private bool shipAlive = true;

    private float m_RotDamping;

	// Use this for initialization
	void Start () 
    {
       handlerMovement = Ship.GetComponent<PlayerShipMovement>();
       m_CamControl = GameObject.Find("Main Camera").GetComponent<CameraController>();
       m_WeapControl = Ship.GetComponent<WeaponController>();

       m_smoothFollow = GameObject.Find("Main Camera").GetComponent<SmoothFollow>();
       m_RotDamping = m_smoothFollow.RotationDamping;
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

		if (Input.GetButton ("Accelerate"))
			handlerMovement.Accelerate ();
		else if (Input.GetButton ("Break"))
			handlerMovement.Break ();

		handlerMovement.Turn ((int)Input.GetAxisRaw("Turn"));

        if (Input.GetButtonDown("Fire1"))
            m_WeapControl.Fire(0);

        if (Input.GetButtonDown("Fire2"))
            m_WeapControl.Fire(1);

        CameraControls();
	}

    private void CameraControls()
    {
        float h = Input.GetAxis("Mouse ScrollWheel");
        m_CamControl.AdjustZoom(h);

        if (Input.GetMouseButton(1))
        {
            m_smoothFollow.RotationDamping = 0;
            float x = Input.GetAxis("Mouse X");
            m_CamControl.AdjustRotation(x);
        }

        else
            m_smoothFollow.RotationDamping = m_RotDamping;
    }
	
}
