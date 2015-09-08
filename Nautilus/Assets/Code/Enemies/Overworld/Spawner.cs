using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
	public float spawnChance = 0.0001f;
	public float spawnDistance = 100f;
	public int maxEnemies = 4;
	public GameObject[] enemies; 
	
	void Update () 
	{
		if (Random.value < spawnChance && gameObject.transform.childCount < maxEnemies)
		{
			spawn();
		}
	}
	
	void spawn()
	{
		float angle = Random.Range(0, 360);
		float x = spawnDistance*Mathf.Sin(angle);
		float z = spawnDistance*Mathf.Cos(angle);
		Vector3 spawnPosition = gameObject.transform.position + new Vector3(x, 0, z);
		GameObject obj = (GameObject)Instantiate(enemies[0], spawnPosition, Quaternion.identity);
		obj.transform.parent = gameObject.transform;
	}
}
	