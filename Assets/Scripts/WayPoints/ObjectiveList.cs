using UnityEngine;
using System.Collections;

public class ObjectiveList : MonoBehaviour {
	public Objective[] objectives;
	private int currentObjective;


	// Use this for initialization
	void Start () {
		foreach (Objective o in objectives) {
			o.setup(gameObject, this);
		}
		StartObjective (0);
	}

	void StartObjective (int number) {
		if (number != objectives.Length) {
			currentObjective = number;
			objectives [number].Begin ();
		}
	}

	public void ChangeObjective () {
		StartObjective (currentObjective + 1);
	}
}
