using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float maxDuration;
	public float currentDuration;
	public float launchVelocity;
	public float acceleration;
	public int damage;

	// Use this for initialization
	void Start () {
		Destroy (transform.gameObject, maxDuration);
		rigidbody2D.AddForce(new Vector2(transform.up.x * launchVelocity, transform.up.y * launchVelocity));
	}
	
	// Update is called once per frame
	void Update () {
	}

}
