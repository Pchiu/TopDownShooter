using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float maxRotationSpeed = 100.0f;
	public float maxDeviationDegrees = 45.0f;
	private Quaternion targetRotation;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 target = mousePos - transform.position;
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
	}
}
