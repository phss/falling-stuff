using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Shape {
    public Vector2 centerOffset = new Vector2(0f, 0f);
    
    private bool canRotate = true;

    void Update() {
        if (IsUpPressed()) {
            if (canRotate) {
                canRotate = false;
                RotateClockwise();
                if (!board.CanFitShape(this)) {
                    RotateCounterClockwise();
                }
            }
       } else {
            canRotate = true;
        }
    }
    
    private bool IsUpPressed() {
        return Input.GetAxis("Vertical") > 0f;
    }

    private void RotateClockwise() {
        Rotate(InvertAll, InvertOnlyY);
    }
    
    private void RotateCounterClockwise() {
        Rotate(InvertOnlyX, InvertAll);
    }

    private void Rotate(Func<float, Vector3> xFun, Func<float, Vector3> yFun) {
        foreach (Transform child in transform) {
            Vector3 rotationInX = xFun(child.localPosition.x - centerOffset.x);
            Vector3 rotationInY = yFun(child.localPosition.y - centerOffset.y);
            child.position += rotationInX + rotationInY;
        }
    }

    private Vector3 InvertAll(float n) {
        return new Vector3(n, n, 0f) * -1;
    }

    private Vector3 InvertOnlyX(float n) {
        return new Vector3(n * -1, n, 0f);
    }

    private Vector3 InvertOnlyY(float n) {
        return new Vector3(n, n * -1, 0f);
    }
}
