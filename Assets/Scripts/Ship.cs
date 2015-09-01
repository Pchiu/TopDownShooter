using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	
	public float acceleration = 10.0f;
	public int rotationSpeed = 180;
	public float maxVelocity = 5.0f;
	public int health = 100;
	public bool hostile;

	public List<Weapon> weapons;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		velocity += move * acceleration * Time.deltaTime;
		transform.position += velocity;

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, 100 * Time.deltaTime);
		*/

	}

	public void FirePrimary()
	{
		//Debug.Log ("Ship.FirePrimary");
		foreach (Weapon weapon in weapons) 
		{
			if (weapon.weaponGroup == "Primary")
			{
				Debug.Log ("Firing " + weapon.weaponName);
				weapon.Fire ();
			}
		}
	}

	public void FireSecondary()
	{
		foreach (Weapon weapon in weapons) 
		{
			if (weapon.weaponGroup == "Secondary")
			{
				Debug.Log ("Firing " + weapon.weaponName);
				weapon.Fire ();
			}
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		if (projectile != null) {
			if ((this.tag == "Hostile" && projectile.tag == "FriendlyShot")
			    || (this.tag == "Friendly" && projectile.tag == "HostileTag")) {
				health -= projectile.damage;
				if (health <= 0) 
				{
					if (this.tag == "Hostile")
					{
						EnemyManager.Instance.RemoveEnemy (this);
					}
					Destroy (gameObject);
				}
				Destroy (collider.gameObject);
			}
		}
	}

}
