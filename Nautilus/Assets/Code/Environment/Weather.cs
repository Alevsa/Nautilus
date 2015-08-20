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
	// How heavily the rain falls. (Max emissivity of the emitter.)
	public float _maxWeatherDensity = 5000;
	public float maxVolume = 0.8f;
	// rate at which the sound effects change in volume
	public float _fadeTime = 1f;
	// This number is a percentage per frame
	public float rainChance = 1f;
	//public float snowChance = 1f;

	// Duration in seconds
	public float _duration = 60f;
	private float duration = 60f;

	private bool weatherActive = false;
	// This will be used to choose what weather happens.
	private float totalProbability;
	// Audio Sources
	private AudioSource rainAudio;
	// Particle emissivity
	private EllipsoidParticleEmitter rainEmitter;
	#endregion

	#region Start method, just gets the audio component(s) and sets up some stuff.
	void Start()
	{
		duration = _duration;
		rainAudio = rainParticles.GetComponent <AudioSource>();
		rainEmitter = rainParticles.GetComponent<EllipsoidParticleEmitter>();	
		//totalProbability = rainChance + snowChance;	
	}
	#endregion

	#region Update method
	void Update () 
	{
		#region Handles the fading in/out of the effect
		if (weatherActive) 
		{
			if (duration >= _fadeTime)
			{
				fadeEffect (true, rainAudio, rainEmitter);
			}
			else if (duration <= _fadeTime)
			{
				fadeEffect(false,rainAudio, rainEmitter); 
			}
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
			if (duration <= 0) {
				rainParticlesToggle ();
				duration = _duration;
			} else {
				duration -= Time.deltaTime;
			}
		}
		#endregion

	}
	#endregion

	#region Toggles the rain particles on and off
	void rainParticlesToggle()
	{
		weatherActive = !weatherActive;
		rainParticles.SetActive (weatherActive);
	}
	#endregion

	#region Fades the effect in/out
	void fadeEffect(bool fadingIn, AudioSource audio, EllipsoidParticleEmitter particles)
	{
		if (audio.volume < maxVolume && fadingIn) {
			audio.volume += (maxVolume/_fadeTime) * Time.deltaTime;
			particles.maxEmission += (_maxWeatherDensity/_fadeTime) * Time.deltaTime;
		} else if (audio.volume >= 0f && !fadingIn) 
		{
			audio.volume -= (maxVolume/_fadeTime) * Time.deltaTime;
			particles.maxEmission -= (_maxWeatherDensity/_fadeTime) * Time.deltaTime;
		}
	}
	#endregion
}
