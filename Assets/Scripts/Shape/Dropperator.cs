using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dropper was taken
public class Dropperator : ShapeControl {
    private float timeSinceLastAutoDrop = 0;
    private float timeSinceLastManualDrop = 0;

    void Update() {
        if (IsSpacePressed()) {
            while(AttemptDrop());
        } else if (ShouldManuallyDrop() || ShouldAutomaticallyDrop()) {
            AttemptDrop();
            timeSinceLastAutoDrop = Time.fixedTime;
            timeSinceLastManualDrop = Time.fixedTime;
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

    private bool ShouldManuallyDrop() {
        return (Time.fixedTime - timeSinceLastManualDrop) > 0.1f && IsDownPressed(); 
    }

    private bool ShouldAutomaticallyDrop() {
        return (Time.fixedTime - timeSinceLastAutoDrop) > 1f;
    }

    private bool IsSpacePressed() {
        return Input.GetButtonDown("Jump");
    }

    private bool IsDownPressed() {
        return Input.GetAxis("Vertical") < 0f;
    }
}
