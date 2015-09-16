using UnityEngine;
using System.Collections;

public class BattleSceneTransition : MonoBehaviour 
{
	public string[] battleScenes;
	public GameObject[] enemies;
	public float spawnDistance = 200f;
	private GameObject player;
	private bool newScene = false;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			string scene = battleScenes[UnityEngine.Random.Range(0,battleScenes.Length)];
			DontDestroyOnLoad(gameObject);
			newScene = true;
			Application.LoadLevel(scene);
		}
	}
	
	void OnLevelWasLoaded()
	{
		Debug.Log("Loaded Level");
		if (newScene)
		{
			player = GameObject.FindGameObjectWithTag("PlayerBattle");
			foreach (GameObject enemy in enemies)
			{
				Debug.Log("Spawning enemy");
				spawnEnemy(enemy);
			}
			Destroy(gameObject);
		}
	}
	
	// Spawns enemy in the battle scene
	void spawnEnemy(GameObject enemy)
	{
	
		float angle = Random.Range(0, 360);
		float x = spawnDistance*Mathf.Sin(angle);
		float z = spawnDistance*Mathf.Cos(angle);
		Vector3 spawnPosition = player.transform.position + new Vector3(x, 0, z);
		Instantiate(enemy, spawnPosition, Quaternion.identity);
		Debug.Log("Enemy should be there");
	}
}
