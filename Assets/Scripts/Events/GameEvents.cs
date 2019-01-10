using System;

public class GameEvents {

    public static event Action OnStart;
    public static void Start() { Invoke(OnStart); }

    public static event Action OnNewGame;
    public static void StartNewGame() { Invoke(OnNewGame); }

    public static event Action OnPause;
    public static void Pause() { Invoke(OnPause); }

    private static void Invoke(Action action) {
        if (action != null) {
            action();
        }
    }
}
