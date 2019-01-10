using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {
    void Awake() {
        GameEvents.OnNewGame += Hide;
        GameEvents.OnGameOver += Show;
    }

    void Update() {
        if (Input.GetButtonDown("Submit")) {
            GameEvents.StartNewGame();
        }
    }

    void Show() {
        gameObject.SetActive(true);
    }

    void Hide() {
        gameObject.SetActive(false);
    }
}
