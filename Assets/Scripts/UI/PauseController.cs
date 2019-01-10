using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {
    void Awake() {
        GameEvents.OnNewGame += Hide;
        GameEvents.OnContinue += Hide;
        GameEvents.OnPause += Show;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            GameEvents.Continue();
        } else if (Input.GetButtonDown("Quit")) {
            Application.Quit();
        } else if (Input.GetButtonDown("Restart")) {
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
