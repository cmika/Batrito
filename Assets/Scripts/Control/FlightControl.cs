using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour {
	public Vector3 forceOffset;
	public Rigidbody drone;
	public float throttleForce;
	public float maxTiltAngle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get Left Stick input in World Space
		/*Vector3 inputVector = new Vector3 (Input.GetAxis ("Left/Right"),
		                                  0,
		                                  Input.GetAxis ("Front/Back"));
		inputVector = Quaternion.AngleAxis (transform.eulerAngles.y, Vector3.up) * inputVector;

		float magnitude = inputVector.magnitude;



		Vector3 desiredUpVector;
		*/
		// Resist Gravity
		Vector3 force = new Vector3 (0, -Physics.gravity.y, 0);

		// Adust for throttle
		float throttle = Input.GetAxis ("Throttle") * throttleForce;
		force = force + new Vector3 (0, throttle, 0);

		// Gravity
		Vector3 gravity = new Vector3(0, Physics.gravity.y, 0);
		
		// Apply forces
		force = transform.TransformVector (force) + gravity;
		drone.AddForceAtPosition (force * drone.mass, forceOffset);
	}
}