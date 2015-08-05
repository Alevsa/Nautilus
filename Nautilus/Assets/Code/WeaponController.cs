using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
    public GameObject Cannon;
    public float FireRate;
    public float CannonPower;
    public float CannonBackForce;
    public Transform[] CannonLocations;
    public GameObject[] Flares;

    private float m_LastFired = 0;
    private Rigidbody shipBody;

    void Start()
    {
        shipBody = GetComponent<Rigidbody>();
        Flares[0].SetActive(false);
        Flares[1].SetActive(false);
    }

    public void Fire(int direction)
    {
        if (Time.time > m_LastFired + FireRate || m_LastFired == 0)
        {
            m_LastFired = Time.time;

            if (direction == 0)
            {
                CreateCannon(CannonLocations[0], -transform.right, Flares[1]);
            }
            else
            {
                CreateCannon(CannonLocations[1], transform.right, Flares[0]);
            }
        }
    }

    private void CreateCannon(Transform cannonLoc, Vector3 dir, GameObject flare)
    {
        GameObject cannon = Instantiate(Cannon,cannonLoc.position, transform.rotation) as GameObject;
        cannon.GetComponent<Rigidbody>().AddForce(dir * CannonPower);
        StartCoroutine(EnableFlare(flare));
    }

    private IEnumerator EnableFlare(GameObject flare)
    {
        flare.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        flare.SetActive(false);
    }
}
