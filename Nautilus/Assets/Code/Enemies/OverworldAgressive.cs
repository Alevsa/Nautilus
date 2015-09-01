using UnityEngine;
using System.Collections;

public class OverworldAgressive : MonoBehaviour 
{
	private bool spottedFocus = false;
	private GameObject focus;

	void Start () 
	{
		focus = GameObject.FindGameObjectWithTag("player");
	}
	void Update () 
	{
		spottedFocus = canISeeMyFocus();
		moveToFocus();
	}
	void moveToFocus()
	{
		gameObject.transform.rotation.SetLookRotation(focus)
	}

	bool canISeeMyFocus()
	{
		return true;
	}
}
