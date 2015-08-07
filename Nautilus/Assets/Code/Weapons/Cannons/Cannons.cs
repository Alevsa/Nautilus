using UnityEngine;
using System.Collections;

public class Cannons : Weapon
{
    private float m_LastFiredRight;
    private float m_LastFiredLeft;

    public override void Start()
    {
        m_LastFiredRight = 0;
        m_LastFiredLeft = 0;
    }

    public override void Fire(int direction, Transform[] MountLocations, FlareHandler[] Flares)
    {
        if (direction == 0)
        {
            if (Time.time > m_LastFiredRight + FireRate || m_LastFiredRight == 0)
            {
                m_LastFiredRight = Time.time;
                InstantiateCannon(MountLocations[0], -transform.right, Flares[1]);
            }
        }
        else
        {
            if (Time.time > m_LastFiredLeft + FireRate || m_LastFiredLeft == 0)
            {
                m_LastFiredLeft = Time.time;
                InstantiateCannon(MountLocations[1], transform.right, Flares[0]);
            }
        }
    }

    private void InstantiateCannon(Transform cannonLoc, Vector3 dir, FlareHandler flare)
    {
        GameObject cannon = Instantiate(Projectile, cannonLoc.position, transform.rotation) as GameObject;
        cannon.GetComponent<Rigidbody>().AddForce(dir * ProjectileForce);
        flare.CannonShot();
    }
}   