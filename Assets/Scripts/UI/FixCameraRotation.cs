using UnityEngine;
using System.Collections;

public class FixCameraRotation : MonoBehaviour {
    void Update() {
        var temp = this.transform.rotation.eulerAngles;
        temp.Set(0, temp.y, 0);
        this.transform.rotation = Quaternion.Euler(temp);
    }
}
