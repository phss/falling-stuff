using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState {
    Splash,
    Playing,
    Paused
}

public class GameController : MonoBehaviour {
    public GameObject splashImage;
    public GameObject pause;
    public GameObject board;

    private GameState state;

    void Start() {
        state = GameState.Splash;
        GameEvents.Start();
    }

    void Update() {
        if (state == GameState.Splash && Input.GetButtonDown("Submit")) {
            StartGame();
        } else if (state == GameState.Playing && Input.GetButtonDown("Cancel")) {
            Pause();
        } else if (state == GameState.Paused) {
            if (Input.GetButtonDown("Cancel")) {
                Unpause();
            } else if (Input.GetButtonDown("Quit")) {
                Application.Quit();
            } else if (Input.GetButtonDown("Restart")) {
                StartGame();
            }
        }
    }

    private void StartGame() {
        state = GameState.Playing;
        splashImage.SetActive(false);
        pause.SetActive(false);
        board.SetActive(true);
        board.SendMessage("Start");
        GameEvents.StartNewGame();
    }

    private void Pause() {
        state = GameState.Paused;
        board.SetActive(false);
        pause.SetActive(true);
        GameEvents.Pause();
    }

    private void Unpause() {
        state = GameState.Playing;
        splashImage.SetActive(false);
        pause.SetActive(false);
        board.SetActive(true);
    }
}
