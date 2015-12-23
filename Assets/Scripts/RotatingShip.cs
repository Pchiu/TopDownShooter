using UnityEngine;
using System.Collections;

public class RotatingShip : Ship {

    // Use this for initialization
    Quaternion upDirection = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    void Start () {
	
	}

    public override void Update()
    {
        base.Update();
        if (specialActive)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, upDirection, rotationSpeed * Time.deltaTime);
        }
    }
}
