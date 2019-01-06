using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float timeSinceLastDrop = 0;

    void Update() {
        if ((Time.fixedTime - timeSinceLastDrop) > 1) {
            transform.Translate(new Vector3(0, -1, 0));
            timeSinceLastDrop = Time.fixedTime;
        }
    }
}
