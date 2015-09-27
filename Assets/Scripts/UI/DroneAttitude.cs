using UnityEngine;
using System.Collections;

public class DroneAttitude : MonoBehaviour {
    public GameObject pitchControl;
    public GameObject yawControl;
    public GameObject rollControl;
    public Transform target;

    void Update() {
        pitchControl.transform.localRotation = Quaternion.AngleAxis(target.eulerAngles.x, Vector3.forward);
        yawControl.transform.localRotation = Quaternion.AngleAxis(target.eulerAngles.y, Vector3.forward);
        rollControl.transform.localRotation = Quaternion.AngleAxis(target.eulerAngles.z, Vector3.forward);
    }
}
