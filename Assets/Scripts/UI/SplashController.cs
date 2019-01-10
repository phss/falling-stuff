using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour {

    void Awake() {
        GameEvents.OnNewGame += Hide;
    }

    void Start() {
        GameEvents.Start(); 
    }

    void Update() {
        if (Input.GetButtonDown("Submit")) {
            GameEvents.StartNewGame();
        }
    }

    void Hide() {
        gameObject.SetActive(false);
    }

}
