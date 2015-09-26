using UnityEngine;
using System.Collections;

public class LiveFeedQuad : MonoBehaviour {
    public Camera target;
    public float offset;

    void Start() {
        float o = target.nearClipPlane + offset;

        float h = Mathf.Tan(target.fieldOfView * Mathf.Deg2Rad * 0.5f) * o * 2f;

        transform.localScale = new Vector3(h * target.aspect, h, 0f);
    }

    void Update() {
        float o = target.nearClipPlane + offset;

        transform.position = target.gameObject.transform.position + target.gameObject.transform.forward * o;
        transform.rotation = target.gameObject.transform.rotation;
    }
}
