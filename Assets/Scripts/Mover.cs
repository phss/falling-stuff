using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Shape {
    private float timeSinceLastMove = 0;

    void Update() {
        if ((Time.fixedTime - timeSinceLastMove) > 0.1f) {
            int horizontal = (int) Input.GetAxis("Horizontal");
            AttemptMove(new Vector3(horizontal, 0f, 0f));
            timeSinceLastMove = Time.fixedTime;
        }
    }
}
