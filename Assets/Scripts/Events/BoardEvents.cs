using System;

public class BoardEvents {
    public static event Action OnShapeStopped;
    public static void ShapeStopped() { Invoke(OnShapeStopped); }

    public static event Action OnSpeedIncreased;
    public static void IncreaseSpeed() { Invoke(OnSpeedIncreased); }

    public static event Action<int> OnLinesCleared;
    public static void ClearedLines(int numberOfLines) {
        if (OnLinesCleared != null) {
            OnLinesCleared(numberOfLines);
        }
    }

    private static void Invoke(Action action) {
        if (action != null) {
            action();
        }
    }
}
