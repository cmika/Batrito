using UnityEngine;
using System.Collections;

public class DroneSync : MonoBehaviour {
    public GameObject target;

    void Update() {
        var temp = target.transform.rotation;
        temp = temp * Quaternion.Euler(90, 0, 0);
        this.transform.rotation = temp;
    }
}
