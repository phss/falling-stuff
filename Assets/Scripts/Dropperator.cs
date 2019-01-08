using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dropper was taken
public class Dropperator : Shape {
    private float timeSinceLastAutoDrop = 0;
    private float timeSinceLastManualDrop = 0;

    void Update() {
        if (IsSpacePressed()) {
            while(AttemptDrop());
        } else if ((Time.fixedTime - timeSinceLastManualDrop) > 0.1f && IsDownPressed()) {
            AttemptDrop();
            timeSinceLastAutoDrop = Time.fixedTime;
            timeSinceLastManualDrop = Time.fixedTime;
        } else if ((Time.fixedTime - timeSinceLastAutoDrop) > 1f) {
            AttemptDrop();
            timeSinceLastAutoDrop = Time.fixedTime;
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

    private bool IsSpacePressed() {
        return Input.GetButtonDown("Jump");
    }

    private bool IsDownPressed() {
        return Input.GetAxis("Vertical") < 0f;
    }
}
