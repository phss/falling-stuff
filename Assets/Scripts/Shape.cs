using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    protected Board board;
    private float timeSinceLastDrop = 0;
    private float timeSinceLastMove = 0;

    void Start() {
        board = transform.parent.GetComponent<Board>();
    }

    void Update() {
        if ((Time.fixedTime - timeSinceLastMove) > 0.1f) {
            int horizontal = (int) Input.GetAxis("Horizontal");
            Move(new Vector3(horizontal, 0f, 0f));
            timeSinceLastMove = Time.fixedTime;
        }

        if ((Time.fixedTime - timeSinceLastDrop) > 1f) {
            bool didMove = Move(Vector3.down);
            if (!didMove) {
                board.Add(this);
                Destroy(gameObject);
            }
            timeSinceLastDrop = Time.fixedTime;
        }
    }

    private bool Move(Vector3 movement) {
        transform.position += movement;
        if (!board.CanFitShape(this)) {
            transform.position += movement * -1;
            return false;
        }
        return true;
    }
    
    public List<Vector3> GetBlockPositions() {
        List<Vector3> positions = new List<Vector3>();
        foreach (Transform child in transform) {
            positions.Add(transform.localPosition + child.localPosition);
        }
        return positions;
    }
}
