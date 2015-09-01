using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	private Transform target;
	public float xTrackSpeed = 5;
	public float yTrackSpeed = 5;
	
	public void SetTarget(Transform transform)
	{
		target = transform;
	}
	
	void LateUpdate() 
	{
		if (target)
		{
			transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
		}
	}
}
