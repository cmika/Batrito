using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	bool active = false;
	protected GameObject player;
	ObjectiveList owner;
	public GameObject[] display;

	public void setup(GameObject p, ObjectiveList o) {
		player = p;
		owner = o;
		foreach (GameObject yeah in display) {
			yeah.SetActive (false);
		}

	}

	public virtual void Begin () {
		active = true;
		foreach (GameObject yeah in display) {
			yeah.SetActive (true);
		}
	}

	public virtual void Complete () {
		active = false;
		owner.ChangeObjective ();
		foreach (GameObject yeah in display) {
			yeah.SetActive (false);
		}
	}
}
