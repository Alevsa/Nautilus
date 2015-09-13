using UnityEngine;
using System.Collections;

public class WeatherEffect : MonoBehaviour 
{
	public float probability;
	public float maxVolume;
	public float duration;
	[HideInInspector] public AudioSource audio;
	[HideInInspector] public GameObject hello;
	[HideInInspector] public ParticleEmitter emitter;
	[HideInInspector] public float timeLeft;
	[HideInInspector] public float maxParticles { get; private set; }

	
	void Awake() 
	{
		emitter = gameObject.GetComponent<ParticleEmitter>();
		maxParticles = emitter.maxEmission;
		Debug.Log("This gameObject is: " + this.gameObject); // <= this works
		Debug.Log("This gameObject is: " + gameObject); // <= this works
		Debug.Log("This gameObject is: " + hello); // <= this works
		hello = gameObject;
		Debug.Log("This gameObject is: " + hello); // <= this works
		emitter.maxEmission = 0f;
	}
}
