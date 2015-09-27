using UnityEngine;
using System.Collections;

public class TriggerObjective : Objective {
	public BoxCollider trigger;
	private bool isTriggering = false;

	// Use this for initialization
	void Start () {
	}

	public override void Begin () {
		base.Begin ();

		isTriggering = true;
	}

	public override void Complete() {
		base.Complete ();
		isTriggering = false;
	}

	void OnTriggerEnter(Collider other) {
		if (isTriggering) {
			if (other.attachedRigidbody.gameObject.Equals (base.player)) {
				Complete ();
			}
		}
	}
}
