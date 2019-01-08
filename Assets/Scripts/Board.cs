﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public GameObject nextShape;
    public Vector2Int dimensions;

    public Transform[,] boardBlocks;

    private RandomShapeFactory shapeFactory;


    void Start() {
        boardBlocks = new Transform[dimensions.x, dimensions.y];  
        shapeFactory = nextShape.GetComponent<RandomShapeFactory>();
        StartNewShape();
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
        GameObject newShape = shapeFactory.Next();
        newShape.transform.parent = transform;
        newShape.transform.localPosition = new Vector3(4f, 19f, 0f);
    }
}
