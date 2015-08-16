using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour 
{
	// This whole script is quite rought but it's functional.
	public GameObject focus;
	public GameObject rainParticles;
	// This number is a percentage
	public float rainChance = 1f;
	// Duration in minutes
	public float _duration = 1f;
	private float duration;
	private bool isRaining = false;

	void start()
	{
		duration = _duration * 3600f;
	}

	void Update () 
	{
		#region Keeps the weather focused on the player, it wont rotate with her though
		gameObject.transform.position = focus.transform.position;
		#endregion

		#region If it's not raining, chance to trigger rain
		if (!isRaining) {
			if (Random.value < rainChance / 100f) {
				rainParticlesToggle ();
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
		isRaining = !isRaining;
		rainParticles.SetActive(isRaining);
	}
}
