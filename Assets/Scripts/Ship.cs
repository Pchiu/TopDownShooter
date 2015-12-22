using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	
	public float acceleration;
	public int rotationSpeed;
	public float maxVelocity;
	public int health;
	public bool hostile;
    public float special;
    public bool specialActive;
    public float specialRegenRate;
    public float specialConsumptionRate;

	public List<Weapon> weapons;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (specialActive)
        {
            if (special <= 0)
            {
                specialActive = false;
                special = 0;
            }
            else
            {
                special -= specialConsumptionRate * Time.deltaTime;
            }
        }
        else
        {
            if (special < 100)
            {
                special += specialRegenRate * Time.deltaTime;
            }
            else if (special >= 100)
            {
                special = 100;
            }
        }
        //Debug.Log("Special: " + special);
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
				weapon.Fire ();
			}
		}
	}

    public void StopPrimary()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon.weaponGroup == "Primary")
            {
                weapon.StopFiring();
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
			    || (this.tag == "Friendly" && projectile.tag == "HostileShot")) {
				health -= projectile.damage;
                var renderer = collider.gameObject.GetComponent<Renderer>();
                hitFlash(renderer);
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

    IEnumerator hitFlash(Renderer renderer)
    {
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(.5f);
        renderer.material.color = Color.white;
    }

}
