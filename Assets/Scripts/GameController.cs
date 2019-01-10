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
    private AudioSource startGameSound;
    private AudioSource pauseSound;

    void Start() {
        state = GameState.Splash;
        startGameSound = GetComponents<AudioSource>()[0];
        pauseSound = GetComponents<AudioSource>()[1];
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
        startGameSound.Play();
        splashImage.SetActive(false);
        pause.SetActive(false);
        board.SetActive(true);
        board.SendMessage("Start");
    }

    private void Pause() {
        state = GameState.Paused;
        pauseSound.Play();
        board.SetActive(false);
        pause.SetActive(true);
    }

    private void Unpause() {
        state = GameState.Playing;
        splashImage.SetActive(false);
        pause.SetActive(false);
        board.SetActive(true);
    }
}
