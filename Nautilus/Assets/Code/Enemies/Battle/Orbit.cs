using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour 
{
	private GameObject target;
	public float orbitRange = 200f;
	
	void Start () 
	{
		GameObject.FindGameObjectWithTag("PlayerBattle");
	}
	
	void Update () 
	{
		
	}
}
