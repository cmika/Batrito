using UnityEngine;
using System.Collections;

public class TriggerObjective : Objective {
	public BoxCollider trigger;
	private bool isTriggering = false;
	private bool isInside = false;

	void Update () {
		if (Input.GetButtonDown ("ReleaseBurrito")) {
			print ("released");
		}
		if (isInside && Input.GetButtonDown ("ReleaseBurrito")) {
			Complete ();
		}
	}

	public override void Begin () {
		base.Begin ();

		isTriggering = true;
	}

	public override void Complete() {
		base.Complete ();
		isTriggering = false;
		print ("delivered");
	}

	void OnTriggerEnter(Collider other) {
		if (isTriggering) {
			if (other.attachedRigidbody.gameObject.Equals (base.player)) {
				isInside = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.attachedRigidbody.gameObject.Equals (base.player)) {
			isInside = false;
		}
	}
}
