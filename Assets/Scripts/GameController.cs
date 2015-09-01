using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public CameraController gameCamera;
	public Transform cameraTarget;
	void Start () {
		gameCamera = GetComponent<CameraController>();
		gameCamera.SetTarget(cameraTarget);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
