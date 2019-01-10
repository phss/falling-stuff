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
        Play(0);
    }

    private void PlayNewGameSound() {
        Play(1);
        GetComponents<AudioSource>()[1].Play();
    }

    private void PlayPauseSound() {
        Play(2);
        GetComponents<AudioSource>()[2].Play();
    }

    private void PlayShapeDroppedSound() {
        Play(3);
        GetComponents<AudioSource>()[3].Play();
    }

    private void PlayLinesClearedSound(int linesCleared) {
        Play(4);
    }

    private void Play(int soundIndex) {
       GetComponents<AudioSource>()[soundIndex].Play();
    }

}
