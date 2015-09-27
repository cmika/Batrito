using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	bool active = false;
	protected GameObject player;
	ObjectiveList owner;

	public void setup(GameObject p, ObjectiveList o) {
		player = p;
		owner = o;
	}

	public virtual void Begin () {
		active = true;
	}

	public virtual void Complete () {
		active = false;
		owner.ChangeObjective ();
	}
}
