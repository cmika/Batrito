using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public float scale;

    void Update() {
        this.transform.localPosition = InputTracking.GetLocalPosition(VRNode.CenterEye) * scale;
    }
}
