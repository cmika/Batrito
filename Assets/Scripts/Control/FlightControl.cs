using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour {
	public Rigidbody drone;
	public float throttleSpeed = 5;
	public float maxTiltAngle = 45;
	public float translationalSpeed = 3;
	public float spinSpeed = 3;
	public GameObject droneModel;
	public float rotateSpeed = 10;
	
	// Update is called once per frame
	void Update () {
		//print (Input.GetAxis ("Spin"));
		drone.AddTorque (new Vector3 (0, Input.GetAxis ("Spin") * spinSpeed, 0));
		
		Vector3 inputVector = new Vector3 (Input.GetAxis ("Left/Right"),
		                                   0,
		                                   Input.GetAxis ("Front/Back"));
		drone.AddRelativeForce (inputVector * translationalSpeed);

		// Resist Gravity
		Vector3 force = new Vector3 ();
		force += new Vector3 (0, -Physics.gravity.y, 0);

		// Adust for throttle
		float throttle = Input.GetAxis ("Throttle") * throttleSpeed;
		force = force + new Vector3 (0, throttle, 0);

		// Gravity
		Vector3 gravity = new Vector3(0, Physics.gravity.y, 0);

		// Apply forces
		force = transform.TransformVector (force) + gravity;
		drone.AddForce (force * drone.mass);


		//code for fake spin

		float tiltAngle = inputVector.magnitude * maxTiltAngle;
		Vector3 tiltAxis = new Vector3 (inputVector.z, 0, -inputVector.x);
		Quaternion tilt = Quaternion.AngleAxis(tiltAngle, tiltAxis);
		Quaternion spin = Quaternion.AngleAxis (drone.transform.rotation.eulerAngles.y, Vector3.up);
		Quaternion desiredRotation = spin * tilt;
		float angle = Quaternion.Angle (desiredRotation, droneModel.transform.rotation);

		droneModel.transform.rotation = Quaternion.Slerp (droneModel.transform.rotation, desiredRotation, rotateSpeed / angle);



		/*float tiltAngle = inputVector.magnitude * maxTiltAngle;

		Vector3 tiltAxis = new Vector3 (inputVector.x, 0, -inputVector.z);

		Vector3 desiredUpVector = Quaternion.AngleAxis (tiltAngle, tiltAxis) * Vector3.left;
		
		Quaternion tilt = Quaternion.Slerp(Quaternion.AngleAxis (tiltAngle, tiltAxis),transform.rotation * NEGATIVESPINSPOOKY, tiltSpeed);

		droneModel.transform.rotation = tilt;*/
	}
}