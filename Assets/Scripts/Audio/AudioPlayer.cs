using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    void Awake() {
        GameEvents.OnStart += PlaySplashSound;
        GameEvents.OnNewGame += PlayNewGameSound;
        GameEvents.OnPause += PlayPauseSound;
        BoardEvents.OnShapeStopped += PlayShapeDroppedSound;
        BoardEvents.OnLinesCleared += PlayLinesClearedSound;
    }

    private void PlaySplashSound() {
        GetComponents<AudioSource>()[0].Play();
    }

    private void PlayNewGameSound() {
        GetComponents<AudioSource>()[1].Play();
    }

    private void PlayPauseSound() {
        GetComponents<AudioSource>()[2].Play();
    }

    private void PlayShapeDroppedSound() {
        GetComponents<AudioSource>()[3].Play();
    }

    private void PlayLinesClearedSound(int linesCleared) {
        GetComponents<AudioSource>()[4].Play();
    }

}
