using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour 
{
	// In minutes
	#region Public variables for for human consumption
	public float _lengthOfDay = 2f;
	public float _maxMoonIntensity = 0.3f;
	public float _maxSunIntensity = 1f;
	public GameObject _sun;
	public GameObject _moon;
	#endregion
	#region converted for use in the machine
	private float maxSunIntensity = 0.5f;
	private float maxMoonIntensity = 0.15f;
	private float lengthOfDay = 120f;
	private Light sun;
	private Light moon;
	#endregion
	
	void OnLevelWasLoaded()
	{
		
	}
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		maxMoonIntensity = _maxMoonIntensity/2f;
		maxSunIntensity = _maxSunIntensity/2f;

		lengthOfDay = _lengthOfDay * 60;
		sun = _sun.GetComponent<Light>();
		moon = _moon.GetComponent<Light>();
	}

	void Update () 
	{
		gameObject.transform.Rotate((360f/lengthOfDay)*Vector3.left*Time.deltaTime);
		sun.intensity = celestialBodyIntensity(gameObject.transform.rotation.x, 1, maxSunIntensity);
		moon.intensity = celestialBodyIntensity(gameObject.transform.rotation.x, -1, maxMoonIntensity);

	}
	// The intensity will go to zero when the opposite celestial body is up to stop strange illumination coming from the earth during hte night time.
	float celestialBodyIntensity(float time, float phase, float maxIntensity)
	{
		return maxIntensity*(phase*Mathf.Sin(0.5f*time)+1);
	}
}
