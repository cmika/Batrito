using UnityEngine;
using System.Collections;

public class FollowDrone : MonoBehaviour {

    public GameObject drone;

    void Update() {
        this.transform.position = drone.transform.position;
    }
}
