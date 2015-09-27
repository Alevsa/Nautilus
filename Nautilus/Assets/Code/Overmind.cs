using UnityEngine;
using System.Collections;

public class Overmind : MonoBehaviour 
{
	// This is going to handle important information I guess so stuff can be loaded. 
	// Main thing it exists for right now is to enable and disable the player depending on the scene,
	// By not destroying hte player we maintain his position in the overworld. By having a loader screen 
	// no duplicate players will be generated as the loader is only called on initialisation. To save 
	// we just need to figure out how to save the loader scene.
	
	GameObject overworldController;
	GameObject overworldPlayer;
	string scene = "Overworld";
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		overworldPlayer = GameObject.FindGameObjectWithTag("Player");
		Application.LoadLevel(scene);
	}
	
	void OnLevelWasLoaded()
	{		
		rememberScene();
		setPlayerActivity();
		if (Application.loadedLevelName != "Overworld")
		{
			// ???
		}
	}
	
	private void rememberScene()
	{
		if (scene != "Loader")
		{
			scene = Application.loadedLevelName;
		}
	}
	
	
	
	#region sets the player prefab to active or inactive depending on the scene
	private void setPlayerActivity()
	{
		if (Application.loadedLevelName == "Overworld")
		{
			overworldPlayer.SetActive(true);
		}
		else 
		{
			overworldPlayer.SetActive(false);
		}
	}
	#endregion
}
