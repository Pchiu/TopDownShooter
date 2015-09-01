using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Ship ship;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		MovePlayerShip ();
		if (Input.GetButtonDown ("Fire1")) 
		{
			ship.FirePrimary();
		}
	}

	void MovePlayerShip()
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		float forward = Input.GetAxis ("Vertical");
		// Use AddRelativeForce for relative controls
		ship.rigidbody2D.AddForce(new Vector2(move.x * ship.acceleration, move.y * ship.acceleration));
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - ship.transform.position);
		ship.transform.rotation = Quaternion.RotateTowards (ship.transform.rotation, targetRotation, ship.rotationSpeed * Time.deltaTime);
	}
}
