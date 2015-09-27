﻿using UnityEngine;
using System.Collections;

public class UIPanel : MonoBehaviour {
    public GameObject to;

    public GameObject camera;

    Vector3 fromPosition;
    Quaternion fromRotation;
    Vector3 fromScale;

    float progress = 0;
    public float transitionTime = 1;

    void Start() {
        fromPosition = transform.position;
        fromRotation = transform.rotation;
        fromScale = transform.localScale;
    }

    void Update() {
        RaycastHit hitinfo = new RaycastHit();
        Ray ray = new Ray(camera.transform.position, camera.transform.TransformVector(Vector3.forward));
        if(Physics.Raycast(ray, out hitinfo)) {
            if(hitinfo.collider.gameObject == this.gameObject){
                progress += Time.deltaTime;
            }
        } else {
            progress -= Time.deltaTime;
        }

        progress = Mathf.Clamp(progress, 0, 0.5f);

        transform.position = Vector3.Lerp(fromPosition, to.transform.position, progress);
        transform.localScale = Vector3.Lerp(fromScale, to.transform.localScale, progress);
        transform.rotation = Quaternion.Lerp(fromRotation, to.transform.rotation, progress);

    }
}
