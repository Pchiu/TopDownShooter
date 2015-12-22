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
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.up.x * launchVelocity, transform.up.y * launchVelocity));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(transform.up.x * acceleration * Time.deltaTime, transform.up.y * acceleration * Time.deltaTime, 0);
	}

}
