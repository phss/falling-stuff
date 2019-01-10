using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    void Awake() {
        GameEvents.OnStart += PlaySplashSound;
        GameEvents.OnNewGame += PlayNewGameSound;
        GameEvents.OnPause += PlayPauseSound;
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

}
