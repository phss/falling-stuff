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
            RotateCounterClockwise();
            timeSinceLastDrop = Time.fixedTime;
        }
    }

    void RotateClockwise() {
        foreach (Transform child in transform) {
            Vector3 normalizedPosition = child.position - transform.position;
            Vector3 rotationInX = InvertAll(normalizedPosition.x - centerOffset.x);
            Vector3 rotationInY = InvertOnlyY(normalizedPosition.y - centerOffset.y);

            child.position += rotationInX + rotationInY;
        }
    }
    
    void RotateCounterClockwise() {
        foreach (Transform child in transform) {
            Vector3 normalizedPosition = child.position - transform.position;
            Vector3 rotationInX = InvertOnlyX(normalizedPosition.x - centerOffset.x);
            Vector3 rotationInY = InvertAll(normalizedPosition.y - centerOffset.y);

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
