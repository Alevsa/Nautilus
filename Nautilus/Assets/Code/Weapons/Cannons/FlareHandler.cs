using UnityEngine;
using System.Collections;

public class FlareHandler : MonoBehaviour
{
    public float SparkDuration = 0.2f;
    public float SmokeDuration = 0.8f;

    private ParticleSystem m_Smoke;
    private ParticleSystem m_Sparks;

    void Start()
    {
        m_Smoke = transform.Find("Smoke").gameObject.GetComponent<ParticleSystem>();
        m_Sparks = transform.Find("Sparks").gameObject.GetComponent<ParticleSystem>();
        m_Sparks.Stop();
        m_Sparks.Clear();
        m_Smoke.Stop();
        m_Smoke.Clear();
    }

    public void CannonShot()
    {
        StartCoroutine(PlayParticles());
    }

    private IEnumerator PlayParticles()
    {
        m_Sparks.Play();
        m_Smoke.Play();
        yield return new WaitForSeconds(SparkDuration);
        m_Sparks.Stop();
        yield return new WaitForSeconds(SmokeDuration);
        m_Smoke.Stop();
    }
}
