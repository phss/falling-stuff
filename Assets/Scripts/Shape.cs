using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    protected Board board;
    private float timeSinceLastDrop = 0;

    void Start() {
        board = transform.parent.GetComponent<Board>();
    }

    void Update() {
        if ((Time.fixedTime - timeSinceLastDrop) > 1f) {
            bool didMove = AttemptMove(Vector3.down);
            if (!didMove) {
                board.Add(this);
                Destroy(gameObject);
            }
            timeSinceLastDrop = Time.fixedTime;
        }
    }

    protected bool AttemptMove(Vector3 movement) {
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
