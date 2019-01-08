using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public Vector2 centerOffset = new Vector2(0f, 0f);

    private float timeSinceLastDrop = 0;

    void Start() {
        Debug.Log(transform.localPosition);
        Debug.Log(transform.GetChild(0).transform.localPosition);
        Debug.Log(transform.GetChild(1).transform.localPosition);
        Debug.Log(transform.GetChild(2).transform.localPosition);
        Debug.Log(transform.GetChild(3).transform.localPosition);
    }

    void Update() {
        if ((Time.fixedTime - timeSinceLastDrop) > 1) {
            // transform.Translate(new Vector3(0, -1, 0));
            // timeSinceLastDrop = Time.fixedTime;
            RotateCounterClockwise();
            timeSinceLastDrop = Time.fixedTime;
        }
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
