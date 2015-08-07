using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
    public GameObject EquippedWeapon;

    public Transform[] MountLocations;
    public FlareHandler[] Flares;

    private AudioSource m_Audio;

    void Start()
    {
        EquipWeapon(EquippedWeapon);
        m_Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        EquippedWeapon.transform.rotation = transform.rotation;
    }

    public void EquipWeapon(GameObject weapon)
    {
        EquippedWeapon = weapon;
        weapon.GetComponent<Weapon>().Start();
    }

    public void Fire(int direction)
    {
        EquippedWeapon.GetComponent<Weapon>().Fire(direction, MountLocations, Flares);
        m_Audio.clip = EquippedWeapon.GetComponent<Weapon>().FiringNoise;
        m_Audio.Play();
    }
}
