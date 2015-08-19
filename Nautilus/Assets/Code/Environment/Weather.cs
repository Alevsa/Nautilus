using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour 
{
	#region Particle systems and focus (The player, though this could be changed to different biomes)
	// This whole script is quite rought but it's functional.
	public GameObject focus;
	public GameObject rainParticles;
	#endregion
	#region Variables, pretty self explanatory from the names.
	public float maxVolume = 0.8f;
	// rate at which the sound effects change in volume
	public float fadeTime = 1f;
	private float _fadeTime = 1f;
	// This number is a percentage per frame
	public float rainChance = 1f;
	//public float snowChance = 1f;
	// Duration in seconds
	public float _duration = 60f;
	private float duration = 60f;

	private bool weatherActive = false;
	// Things that need fixing
	private float totalProbability;
	private AudioSource rainAudio;
	#endregion

	void start()
	{
		duration = _duration;
		fadeTime = _fadeTime;
		rainAudio = rainParticles.GetComponent <AudioSource>();
		//totalProbability = rainChance + snowChance;	
	}

	void Update () 
	{
		#region Handles the fading in/out of the audio
		if (weatherActive) {
			fadeRainAudio (true, rainParticles);
		}
		if (_duration <= fadeTime && weatherActive)
		{
			fadeRainAudio(false,rainParticles); 
		}
		#endregion

		#region Keeps the weather focused on the player, it wont rotate with her though
		gameObject.transform.position = focus.transform.position;
		#endregion

		#region If it's not raining, chance to trigger rain [I'll change this to allow a chance of snow and other stuff later.]
		if (!weatherActive) {
			if (Random.value < rainChance / 100f) {
				rainParticlesToggle ();
			}
		} 
		#endregion

		#region Else if the duration is up, stop raining or tick down the duration
		else {
			if (duration == 0) {
				rainParticlesToggle ();
				duration = _duration;
			} else {
				duration -= Time.deltaTime;
			}
		}
		#endregion

	}
	#region Toggles the rain particles on and off
	void rainParticlesToggle()
	{
		weatherActive = !weatherActive;
		rainParticles.SetActive (weatherActive);
	}
	#endregion

	#region Fades the audio in [and later will fade it out]
	void fadeRainAudio(bool fadingIn, GameObject source)
	{
		AudioSource audio = source.GetComponent<AudioSource>();
		if (audio.volume < maxVolume && fadingIn) {
			audio.volume += (maxVolume/fadeTime) * Time.deltaTime;
		} else if (audio.volume >= 0f && !fadingIn) 
		{
			audio.volume -= (maxVolume/fadeTime) * Time.deltaTime;
		}
	}
	#endregion
}
