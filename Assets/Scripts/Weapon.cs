using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public string weaponName;
	public string weaponType;
	public string weaponGroup;
	public float fireDelay;
	public Projectile projectile;
	public GameObject shotOrigin;

	public void Fire()
	{
        InvokeRepeating("Shoot", .001f, fireDelay);
	}

    public void StopFiring()
    {
        CancelInvoke("Shoot");
    }

    public void Shoot()
    {
        Projectile shot = (Projectile)Instantiate(projectile, shotOrigin.transform.position, transform.rotation);
    }
}
