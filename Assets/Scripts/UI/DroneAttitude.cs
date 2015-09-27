using UnityEngine;
using System.Collections;

public class DroneAttitude : MonoBehaviour {
    public GameObject pitchControl;
    public GameObject yawControl;
    public GameObject rollControl;
    public Transform target;

    void Update() {
        pitchControl.transform.localRotation = Quaternion.Euler(270, 0, target.eulerAngles.x);
        yawControl.transform.localRotation = Quaternion.Euler(270, 0, target.eulerAngles.y);
        rollControl.transform.localRotation = Quaternion.Euler(270, 0, target.eulerAngles.z);
    }
}
