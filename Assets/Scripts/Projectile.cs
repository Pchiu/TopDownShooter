using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float maxDuration;
	public float currentDuration;
	public float acceleration;
	public int damage;
	public Ship target;
	// Use this for initialization
	void Start () {
		Destroy (transform.gameObject, maxDuration);
		rigidbody2D.AddForce(new Vector2(transform.up.x * acceleration, transform.up.y * acceleration));
	}
	
	// Update is called once per frame
	void Update () {
		// If this projectile has a target, we assume it is a guided projectile.
		if (target)
		{

		}
	}

}
