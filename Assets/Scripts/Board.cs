using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public Vector2 dimensions;

    void Start() {
        
    }

    void Update() {
        
    }

    public bool IsValid(Shape shape) {
        foreach (Vector3 position in shape.GetBlockPositions()) {
            if (position.x < 0 || position.x >= dimensions.x || position.y < 0 || position.y >= dimensions.y) {
                return false;
            }
        }
        return true;
    }
}
