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
        if (Input.GetButtonUp ("Fire1"))
        {
            ship.StopPrimary();
        }
	}

	void MovePlayerShip()
	{
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Debug.Log(move);
        ship.transform.position += move * ship.acceleration * Time.deltaTime;
        /*
        if (Input.GetKey(KeyCode.A))
        {
            ship.transform.position += Vector3.left * ship.acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ship.transform.position += Vector3.right * ship.acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ship.transform.position += Vector3.up * ship.acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ship.transform.position += Vector3.down * ship.acceleration * Time.deltaTime;
        }
        */
        /*
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		float forward = Input.GetAxis ("Vertical");
		// Use AddRelativeForce for relative controls
		ship.GetComponent<Rigidbody2D>().AddForce(new Vector2(move.x * ship.acceleration, move.y * ship.acceleration));
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Input.mousePosition);
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - ship.transform.position);
        //Debug.Log(targetRotation);
		ship.transform.rotation = Quaternion.RotateTowards (ship.transform.rotation, targetRotation, ship.rotationSpeed * Time.deltaTime);
        */
	}
}
