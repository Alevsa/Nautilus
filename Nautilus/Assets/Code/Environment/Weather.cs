using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour 
{
	// This whole script is quite rought but it's functional.
	public GameObject focus;
	public GameObject rainParticles;
	// rate at which the sound effects change in volume
	public float volumeIncreaseSpeed = 0.01f;
	// This number is a percentage per frame
	public float rainChance = 1f;
	public float snowChance = 1f;
	// Duration in minutes
	public float _duration = 1f;
	private float totalProbability;
	private float duration;
	private bool weatherActive = false;

	void start()
	{
		totalProbability = rainChance + snowChance;
		duration = _duration * 3600f;
	}

	void Update () 
	{
		#region Keeps the weather focused on the player, it wont rotate with her though
		gameObject.transform.position = focus.transform.position;
		#endregion

			#region If it's not raining, chance to trigger rain [I'll change this to allow a chance of snow and other stuff later.]
		if (!weatherActive) {
			if (Random.value < rainChance / 100f) {
				rainParticlesToggle ();
				fadeAudio(rainParticles, true);
			}
		} 
		#endregion

		#region Else if the duration is up, stop raining or tick down the duration
		else {
			if (duration == 0) {
				rainParticlesToggle ();
				duration = _duration * 3600f;
			} else {
				duration--;
			}
		}
		#endregion
	}

	void rainParticlesToggle()
	{
		weatherActive = !weatherActive;
		rainParticles.SetActive (weatherActive);
	}

	void fadeAudio(GameObject weatherEffect, bool fadingIn)
	{
		AudioSource audio = weatherEffect.GetComponent <AudioSource>();
		if (audio.volume < 0.8f && fadingIn) {
			audio.volume += volumeIncreaseSpeed;
		} else if (!fadingIn) 
		{
			audio.volume -= volumeIncreaseSpeed;
		}
	}
}
