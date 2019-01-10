using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private Board board;

    void Awake() {
        board = GetComponent<Board>();
        GameEvents.OnNewGame += board.ResetBoard;
        GameEvents.OnNewGame += Enable;
        GameEvents.OnContinue += Enable;
        GameEvents.OnPause += Disable;
    }

    void Start() {
        GameEvents.Start(); 
    }

    void Enable() {
        gameObject.SetActive(true);
    }

    void Disable() {
        gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            GameEvents.Pause();
        }
    }
}
