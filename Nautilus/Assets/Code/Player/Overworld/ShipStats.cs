using UnityEngine;
using System.Collections;

public class ShipStats : MonoBehaviour 
{
	public int MaxSpeed;
	public float Acceleration;
	public float TurnRate;
	public int Health;
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void OnLevelWasLoaded()
	{
		if (Application.loadedLevelName == "Overworld")
		{
			gameObject.SetActive(true);
		}
		else 
		{
			gameObject.SetActive(false);
		}
	}
}
