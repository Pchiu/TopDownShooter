using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float maxDuration;
	public float currentDuration;
	public float speed;
	public int damage;
    public ProjectileBehavior behavior;

	// Use this for initialization
	void Start () {
		Destroy (transform.gameObject, maxDuration);
	}
	
	// Update is called once per frame
	void Update () {
        behavior.Action(transform, speed);
	}

}
