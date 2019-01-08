using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public Vector2Int dimensions;
    public GameObject shape;

    public Transform[,] boardBlocks;

    void Start() {
        boardBlocks = new Transform[dimensions.x, dimensions.y];  
    }

    public void Add(Shape shape) {
        List<Transform> local = new List<Transform>();
        foreach (Transform block in shape.transform) {
            Vector3 blockPosition = shape.transform.localPosition + block.localPosition;
            boardBlocks[(int) blockPosition.x, (int) blockPosition.y] = block;
            local.Add(block);
        }
        foreach (Transform block in local) {
            block.parent = transform;
        }
        // ClearCompletedRows();
        StartNewShape();
    }

    public bool CanFitShape(Shape shape) {
        foreach (Vector3 position in shape.GetBlockPositions()) {
            if (position.x < 0 || position.x >= dimensions.x || position.y < 0 || position.y >= dimensions.y || boardBlocks[(int) position.x, (int) position.y] != null) {
                return false;
            }
        }
        return true;
    }

    private void ClearCompletedRows() {

    }

    private void StartNewShape() {
        GameObject newShape = Instantiate(shape, transform) as GameObject;
        newShape.transform.localPosition = new Vector3(4f, 19f, 0f);
    }
}
