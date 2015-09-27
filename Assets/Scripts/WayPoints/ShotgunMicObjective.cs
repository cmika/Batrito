using UnityEngine;
using System.Collections;

public class ShotgunMicObjective : Objective {
	public BoxCollider trigger;
	private bool isTriggering = false;
	private bool isInsideTrigger = false;
	private bool isButtonPushed = false;
	
	void Update() {
		if (Input.GetButtonDown ("ShotgunMic")) {
			isButtonPushed = true;
		}
		if (Input.GetButtonUp ("ShotgunMic")) {
			isButtonPushed = false;
			ResetTimer ();
		}

		if (isButtonPushed && isInsideTrigger) {
			TimerStep ();
		}
	}
	
	public override void Begin () {
		base.Begin ();
		
		isTriggering = true;
	}
	
	public override void Complete() {
		base.Complete ();
		isTriggering = false;
		isInsideTrigger = false;
		ResetTimer ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (isTriggering) {
			if (other.attachedRigidbody.gameObject.Equals (base.player)) {
				isInsideTrigger = true;
				ResetTimer ();
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.attachedRigidbody.gameObject.Equals (base.player)) {
			isInsideTrigger = false;
		}
	}

	// Timer shit

	private float timer = 0;
	public float listenTime;

	void ResetTimer () {
		timer = 0;
	}

	void TimerStep () {
		timer += Time.deltaTime;
		if (timer >= listenTime)
			Complete ();
	}

}