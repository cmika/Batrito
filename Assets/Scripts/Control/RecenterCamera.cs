using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class RecenterCamera : MonoBehaviour {
    void Update() {
        if(Input.GetButtonDown("ResetCamera")) {
            InputTracking.Recenter();
        }
    }
}
