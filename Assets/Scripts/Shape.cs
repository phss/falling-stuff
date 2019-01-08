using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    protected Board board;

    void Start() {
        board = transform.parent.GetComponent<Board>();
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
