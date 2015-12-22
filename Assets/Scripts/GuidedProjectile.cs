using UnityEngine;
using System.Collections;

public class GuidedProjectile : Projectile {

	public Ship target;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		Destroy (transform.gameObject, maxDuration);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.up.x * launchVelocity, transform.up.y * launchVelocity));
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			// Spend one frame acquiring a new target;
			target = EnemyManager.Instance.FindNearestEnemy (this.transform.position);
		}
		else
		{
			Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

		}
        transform.position += new Vector3(transform.up.x * acceleration * Time.deltaTime, transform.up.y * acceleration * Time.deltaTime, 0);
	}
}
