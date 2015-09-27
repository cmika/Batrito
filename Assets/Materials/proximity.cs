using UnityEngine;
using System.Collections;

public class proximity : MonoBehaviour {
    public GameObject target;

    void Update() {
        if ((this.transform.position - target.transform.position).magnitude < 10) {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
