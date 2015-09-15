using UnityEngine;
using System.Collections;

public class WeatherEffect : MonoBehaviour 
{
	public float probability;
	public float maxVolume;
	public float duration;
	public float fadeTime = 5f;
	[HideInInspector] public AudioSource audio;
	[HideInInspector] public GameObject hello;
	[HideInInspector] public ParticleEmitter emitter;
	[HideInInspector] public float timeLeft;
	[HideInInspector] public float maxParticles { get; private set; }

	
	void Awake() 
	{
		emitter = gameObject.GetComponent<ParticleEmitter>();
		maxParticles = emitter.maxEmission;
		hello = gameObject;
	}
	
	void Start()
	{
		emitter.maxEmission = 0f;
		fadein();
	}
	
	IEnumerable fadein()
	{
		while (emitter.maxEmission < maxParticles)
		{
			emitter.maxEmission += fadeTime * Time.deltaTime;
			yield return null;
		}
	}
}
