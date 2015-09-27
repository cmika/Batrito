using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour {
	public Vector3 forceOffset;
	public Rigidbody drone;
	public float throttleForce;
	public float maxTiltAngle;
	public float tiltSpeed;
	public float spinForce;
	
	// Update is called once per frame
	void Update () {
		//print (Input.GetAxis ("Spin"));
		drone.AddTorque (new Vector3 (0, Input.GetAxis ("Spin") * spinForce, 0));

		/*Quaternion spin = Quaternion.AngleAxis (transform.eulerAngles.y, Vector3.forward);
		Quaternion NEGATIVESPINSPOOKY = Quaternion.AngleAxis (-transform.eulerAngles.y, Vector3.up);
		// Get Left Stick input in World Space
		Vector3 inputVector = new Vector3 (Input.GetAxis ("Left/Right"),
		                                  0,
		                                  Input.GetAxis ("Front/Back"));
		inputVector = spin * inputVector;

		float tiltAngle = inputVector.magnitude * maxTiltAngle;

		Vector3 tiltAxis = new Vector3 (inputVector.x, 0, -inputVector.z);

		Vector3 desiredUpVector = Quaternion.AngleAxis (tiltAngle, tiltAxis) * Vector3.left;
		
		Quaternion tilt = Quaternion.Slerp(Quaternion.AngleAxis (tiltAngle, tiltAxis),transform.rotation * NEGATIVESPINSPOOKY, tiltSpeed);

		transform.rotation = tilt;*/
		
		// Resist Gravity
		Vector3 force = new Vector3 ();
		force += new Vector3 (0, -Physics.gravity.y, 0);

		// Adust for throttle
		float throttle = Input.GetAxis ("Throttle") * throttleForce;
		force = force + new Vector3 (0, throttle, 0);

		// Gravity
		Vector3 gravity = new Vector3(0, Physics.gravity.y, 0);

		// Apply forces
		force = transform.TransformVector (force) + gravity;
		drone.AddForceAtPosition (force * drone.mass, transform.TransformPoint(forceOffset));
	}
}