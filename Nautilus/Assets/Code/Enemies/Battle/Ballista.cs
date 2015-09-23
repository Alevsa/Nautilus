using UnityEngine;
using System.Collections;

public class Ballista : MonoBehaviour 
{
	public Transform target;
	public GameObject pointer;
	public GameObject projectile;
	public float range = 10f;
	public float turnRate = 0.8f;
	public float cooldown = 5f;
	private float _cooldown;
	private bool onCooldown = false;
	
	void Start () 
	{
		_cooldown = cooldown;
		target = GameObject.FindGameObjectWithTag("PlayerBattle").transform;
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				pointer = obj;
			}
		}
	}

	void Update () 
	{
		checkCooldown();	
		rotateTurret();
		if (iShouldShoot() && !onCooldown)
		{
			shoot();
		}
	}

	void rotateTurret()
	{
		pointer.transform.LookAt(target);
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, pointer.transform.rotation, turnRate);
	}
	
	bool iShouldShoot()
	{	
		return Physics.Raycast(transform.position, gameObject.transform.forward, range);
	}
	
	void shoot()
	{
		Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
		onCooldown = true;
		StartCoroutine("setCooldown");
	}	
	
	void checkCooldown()
	{
		if (_cooldown <= 0f)
		{
			onCooldown = false;
			_cooldown = cooldown;
		}
	}
	
	public IEnumerator setCooldown()
	{
		while (_cooldown > 0f)
		{
			_cooldown -= Time.deltaTime;
			yield return null;
		} 
	}
}
