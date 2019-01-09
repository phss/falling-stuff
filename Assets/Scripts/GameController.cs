using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState {
    Splash,
    Playing
}

public class GameController : MonoBehaviour {
    public GameObject splashImage;
    public GameObject board;

    private GameState state;
    private AudioSource startGameSound;

    void Start() {
        state = GameState.Splash;
        board.SetActive(false);
        startGameSound = GetComponent<AudioSource>();
    }

    void Update() {
        if (state == GameState.Splash && Input.GetButtonDown("Submit")) {
            state = GameState.Playing;
            StartGame();
        }
    }

    private void StartGame() {
        splashImage.SetActive(false);
        board.SetActive(true);
        startGameSound.Play();
    }
}
