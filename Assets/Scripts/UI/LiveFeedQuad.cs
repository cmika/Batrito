using UnityEngine;
using System.Collections;

public class LiveFeedQuad : MonoBehaviour {
    public Camera target;
    public GameObject drone;
    public GameObject ui;
    public float offset;

    void Start() {
        float o = target.nearClipPlane + offset;

        float h = Mathf.Tan(target.fieldOfView * Mathf.Deg2Rad * 0.5f) * o * 2f;

        transform.localScale = new Vector3(h * target.aspect, h, 0f);
    }

    void Update() {
        float o = target.nearClipPlane + offset;

        transform.localPosition = ui.transform.localPosition + Vector3.forward * o;
        transform.rotation = drone.transform.rotation;
    }
}
