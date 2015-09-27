using UnityEngine;
using System.Collections;

public class MapMarker : MonoBehaviour {

    public GameObject target;

    void Update() {
        //400 - 700 x
        //0 - 300 z
        var x = (300 - (target.transform.position.x - 400)) / 300;
        var y = (300 - target.transform.position.z) / 300;
        x = x * (3.8f * 2) - 3.8f;
        y = y * (3.8f * 2) - 3.8f;

        this.transform.localPosition = new Vector3(x, y, 2);
    }
}
