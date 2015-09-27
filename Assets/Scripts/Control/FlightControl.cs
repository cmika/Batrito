using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour {
	public Vector3 forceOffset;
	public Rigidbody drone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Gravity
		Vector3 gravity = new Vector3(0, Physics.gravity.y, 0);

		// Resist Gravity
		Vector3 force = new Vector3 (0, -Physics.gravity.y, 0);

		// Adust for throttle



		// Apply forces 
		drone.AddForceAtPosition (force, forceOffset);

		print (drone.velocity);
	}
}
