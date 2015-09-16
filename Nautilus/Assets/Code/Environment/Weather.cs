using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weather : MonoBehaviour 
{
	public GameObject focus; // The player most likely
	public float chanceForWeather = 0.001f;
	public float fadeRate = 1f;
	public float duration = 60f;
	public WeatherEffect[] weatherEffects;
	private bool active = false;
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		weatherEffects = GetComponentsInChildren<WeatherEffect>(true);
		// Placeholder for durations not decided exactly what I want to do here.
		foreach (WeatherEffect effect in weatherEffects)
		{
			effect.duration = duration;	
		}
	}
	
	void Update()
	{
		if (Random.value < chanceForWeather && !active)
		{
			WeatherEffect activeEffect = weatherRoulette();
			activeEffect.hello.SetActive(true);
		}
	}
	
	#region Routlette selection for a weather effect
	WeatherEffect weatherRoulette()
	{
		float totalProbability = 0;
		foreach (WeatherEffect effect in weatherEffects)
		{
			totalProbability += effect.probability;
		}
		float spin = Random.value*totalProbability;
		float total = 0;
		foreach (WeatherEffect effect in weatherEffects)
		{
			total += effect.probability;
			if (spin < total)
			{
				return effect;
			} 
		}
		return weatherEffects[0];
	}
	#endregion
	
	IEnumerator fadeEffect(WeatherEffect effect, bool fadingIn)
	{
		while (effect.emitter.maxEmission < effect.maxParticles)
		{
			effect.emitter.maxEmission += fadeRate;
			yield return null;
		}
	}
	
		
}
