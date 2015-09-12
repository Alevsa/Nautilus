using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weather : MonoBehaviour 
{
	public GameObject focus; // The player most likely
	private List<WeatherEffect> weatherEffects;
	public float chanceForWeather = 0.001f;
	public float fadeRate = 1f;
	private bool active = false;
	
	void Start()
	{
		for (int i = 0; i < gameObject.transform.GetChildCount(); i++)
		{
			GameObject x = gameObject.transform.GetChild(i);
			weatherEffects.Add(x.GetComponent<WeatherEffect>());
		}
	}
	
	void Update()
	{
		if (Random.value < chanceForWeather && !active)
		{
			WeatherEffect active = weatherRoulette();
			
			active.effect.SetActive = true;
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
	}
	#endregion
	
	IEnumerator fadeEffect(WeatherEffect effect, bool fadingIn)
	{
		while (effect.effect.GetComponent(ParticleSystem) < effect.maxParticles )
	}
		
}
