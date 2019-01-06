using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public Vector2 centerOffset = new Vector2(0f, 0f);

    private float timeSinceLastDrop = 0;

    void Start() {
        Debug.Log(transform.position);
        Debug.Log(transform.GetChild(0).transform.position);
        Debug.Log(transform.GetChild(1).transform.position);
        Debug.Log(transform.GetChild(2).transform.position);
        Debug.Log(transform.GetChild(3).transform.position);
    }

    void Update() {
        if ((Time.fixedTime - timeSinceLastDrop) > 1) {
            // transform.Translate(new Vector3(0, -1, 0));
            // timeSinceLastDrop = Time.fixedTime;
            RotateClockwise();
            timeSinceLastDrop = Time.fixedTime;
        }
    }

    void RotateClockwise() {
        foreach (Transform child in transform) {
            Vector3 normalizedPosition = child.position - transform.position;
            Vector3 rotationInX = GetRotationInX(normalizedPosition.x - centerOffset.x);
            Vector3 rotationInY = GetRotationInY(normalizedPosition.y - centerOffset.y);

            child.position += rotationInX + rotationInY;
        }
    }

    private Vector3 GetRotationInX(float x) {
        return new Vector3(x * -1, x * -1, 0f);
    }
    private Vector3 GetRotationInY(float y) {
        return new Vector3(y, y * -1, 0f);
    }
}
