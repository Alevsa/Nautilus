﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Target;
	public CameraControlNew cameraControl;

	// Use this for initialization
	void Start () 
	{		
		if (Application.loadedLevelName == "Overworld")
		{
			Target = GameObject.FindGameObjectWithTag("Player");
		}
		else 
		{
			Target = GameObject.FindGameObjectWithTag("PlayerBattle");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = Target.transform.position + cameraControl.newPosition;

		Vector3 direction = (Target.transform.position - this.transform.position).normalized;
		this.transform.rotation = Quaternion.LookRotation (direction);
	}
}
