using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public string weaponName;
	public string weaponType;
	public string weaponGroup;
	public float fireRate;
	public Projectile projectile;
	public GameObject shotOrigin;

	public void Fire()
	{
		Projectile shot = (Projectile)Instantiate(projectile, shotOrigin.transform.position, transform.rotation);
	}
}
