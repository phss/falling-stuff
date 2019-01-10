using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : ShapeControl {
    public float repeatMoveTime = 0.3f;
    public float subsequentMovesTime = 0.05f;

    private float timeSinceLastMove = 0;
    private int moves = 0;

    void Update() {
        int movement = (int) Input.GetAxis("Horizontal");
        if (movement == 0) {
            moves = 0;
            return;
        }

        bool isStopped = moves == 0;
        bool canDoFirstRepeatMove = moves == 1 && (Time.fixedTime - timeSinceLastMove) > repeatMoveTime;
        bool canDoSubsequentMoves = moves > 1 && (Time.fixedTime - timeSinceLastMove) > subsequentMovesTime;

        if (isStopped || canDoFirstRepeatMove || canDoSubsequentMoves) {
            moves++;
            AttemptMove(new Vector3(movement, 0f, 0f));
            timeSinceLastMove = Time.fixedTime;
        }
    }
}
