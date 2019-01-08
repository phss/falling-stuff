using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dropper was taken
public class Dropperator : Shape {
    private float timeSinceLastDrop = 0;

    void Update() {
        if ((Time.fixedTime - timeSinceLastDrop) > 1f) {
            bool didMove = AttemptMove(Vector3.down);
            if (!didMove) {
                board.Add(this);
                Destroy(gameObject);
            }
            timeSinceLastDrop = Time.fixedTime;
        }
    }
}
