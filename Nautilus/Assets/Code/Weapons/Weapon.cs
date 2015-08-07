using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    public GameObject Projectile;
    public float FireRate; 
    public float ProjectileForce;
    public float ProjectileBackForce;

    public AudioClip FiringNoise;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Fire(int direction, Transform[] MountLocations, FlareHandler[] Flares)
    {

    }

    public virtual void InstantiateProjectile(Transform mountLoc, Vector3 dir)
    {

    }
}
