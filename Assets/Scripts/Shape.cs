using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public Vector2 centerOffset = new Vector2(0f, 0f);

    private Board board;
    private float timeSinceLastMove = 0;

    void Start() {
        board = transform.parent.GetComponent<Board>();

        Debug.Log(board);
        // Debug.Log(transform.localPosition);
        // foreach (Vector3 pos in GetBlockPositions()) {
        //     Debug.Log(pos);
        // }
    }

    void Update() {
        if ((Time.fixedTime - timeSinceLastMove) > 0.1f) {
            int horizontal = (int) Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontal, 0f, 0f);

            transform.position += movement;
            if (!board.IsValid(this)) {
                transform.position += movement * -1;
            }

            timeSinceLastMove = Time.fixedTime;
        }
    }
    
    public List<Vector3> GetBlockPositions() {
        List<Vector3> positions = new List<Vector3>();
        foreach (Transform child in transform) {
            positions.Add(transform.localPosition + child.localPosition);
        }
        return positions;
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
