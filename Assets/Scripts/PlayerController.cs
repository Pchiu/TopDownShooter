using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Ship ship;
    Quaternion upDirection = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    public Slider specialBarSlider;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = left.x;
        xMax = right.x;
        Vector3 top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        yMin = bottom.y;
        yMax = top.y;
        Debug.Log("xMin: " + xMin);
        Debug.Log("xMax: " + xMax);
        Debug.Log("yMin: " + yMin);
        Debug.Log("yMax: " + yMax);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			ship.FirePrimary();
		}
        if (Input.GetButtonUp ("Fire1"))
        {
            ship.StopPrimary();
        }
        if (Input.GetButtonDown ("Fire2"))
        {
            ship.specialActive = true;
        }
        if (Input.GetButtonUp ("Fire2"))
        {
            ship.specialActive = false;
        }
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        MoveShip();
        specialBarSlider.value = ship.special;
    }

    void MoveShip()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        ship.transform.position += move * ship.acceleration * Time.deltaTime;
        var clampedX = Mathf.Clamp(ship.transform.position.x, xMin, xMax);
        var clampedY = Mathf.Clamp(ship.transform.position.y, yMin, yMax);
        ship.transform.position = new Vector3(clampedX, clampedY, ship.transform.position.z);
    }
}
