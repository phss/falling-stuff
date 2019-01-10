using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShapeFactory : MonoBehaviour {
    public GameObject[] shapes;

    public GameObject nextShape;

    void Start() {
        GenerateNextShape();
    }

    public GameObject Next() {
        GameObject shapeToBePlayed = nextShape;
        SetScriptStatus(shapeToBePlayed, true);

        transform.DetachChildren();
        GenerateNextShape();

        return shapeToBePlayed;
    }

    private void GenerateNextShape() {
        nextShape = Instantiate(GetRandom(shapes), transform) as GameObject;
        SetScriptStatus(nextShape, false);
    }

    private void SetScriptStatus(GameObject shape, bool enabled) {
        foreach (ShapeControl script in shape.GetComponents<ShapeControl>()) {
            script.enabled = enabled;
        }
    }
    
    private GameObject GetRandom(GameObject[] objects) {
        return objects[Random.Range(0, objects.Length)];
    }
}
