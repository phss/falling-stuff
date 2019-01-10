using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public GameObject nextShape;
    public Vector2Int dimensions;

    public Transform[,] boardBlocks;

    private RandomShapeFactory shapeFactory;


    void Start() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        boardBlocks = new Transform[dimensions.x, dimensions.y];  
        shapeFactory = nextShape.GetComponent<RandomShapeFactory>();
        StartNewShape();
    }

    public bool CanFitShape(ShapeControl shape) {
        foreach (Vector3 position in shape.GetBlockPositions()) {
            bool outOfBounds = position.x < 0 || position.x >= dimensions.x || position.y < 0 || position.y >= dimensions.y;

            if (outOfBounds || boardBlocks[(int) position.x, (int) position.y] != null) {
                return false;
            }
        }
        return true;
    }

    public void Add(ShapeControl shape) {
        AddBlocksFrom(shape);
        ClearCompletedRows();
        StartNewShape();
    }

    private void AddBlocksFrom(ShapeControl shape) {
        List<Transform> local = new List<Transform>();
        foreach (Transform block in shape.transform) {
            Vector3 blockPosition = shape.transform.localPosition + block.localPosition;
            boardBlocks[(int) blockPosition.x, (int) blockPosition.y] = block;
            local.Add(block);
        }
        foreach (Transform block in local) {
            block.parent = transform;
        }
    }

    private void ClearCompletedRows() {
        for (int row = dimensions.y - 1; row >= 0; row--) {
            if (IsRowFilled(row)) {
                ClearRow(row);
            }
        }
    }

    private bool IsRowFilled(int row) {
        for (int col = 0; col < dimensions.x; col++) {
            if (boardBlocks[col, row] == null) {
                return false;
            }
        }
        return true;
    }

    private void ClearRow(int rowToDelete) {
        for (int col = 0; col < dimensions.x; col++) {
            Destroy(boardBlocks[col, rowToDelete].gameObject);
        }

        for (int row = rowToDelete; row < dimensions.y; row++) {
            for (int col = 0; col < dimensions.x; col++) {
                boardBlocks[col, row] = null;
                if ((row + 1) < dimensions.y) {
                    boardBlocks[col, row] = boardBlocks[col, row+1];
                    if (boardBlocks[col, row] != null) {
                        boardBlocks[col, row].position += Vector3.down;
                    }
                }
            }
        }
    }

    private void StartNewShape() {
        GameObject newShape = shapeFactory.Next();
        newShape.transform.parent = transform;
        newShape.transform.localPosition = new Vector3(4f, 19f, 0f);
    }
}
