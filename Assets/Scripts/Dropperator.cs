using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dropper was taken
public class Dropperator : Shape {
    private float timeSinceLastDrop = 0;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            while(AttemptDrop());
        } else if ((Time.fixedTime - timeSinceLastDrop) > 1f) {
            AttemptDrop();
            timeSinceLastDrop = Time.fixedTime;
        }
    }

    private bool AttemptDrop() {
        bool didMove = AttemptMove(Vector3.down);
        if (!didMove) {
            board.Add(this);
            Destroy(gameObject);
        }
        return didMove;
    }
}
