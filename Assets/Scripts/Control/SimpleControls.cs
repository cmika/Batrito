using UnityEngine;
using System.Collections;

public class SimpleControls : MonoBehaviour {

	public Rigidbody drone;
	public float speed;

	// Update is called once per frame
	void Update () {
		// movement on the Y plane
		Vector3 movement = new Vector3(Input.GetAxis("Front/Back"),
		                               0,
		                               Input.GetAxis ("Left/Right"));
		drone.velocity = movement * speed;
	}
}
