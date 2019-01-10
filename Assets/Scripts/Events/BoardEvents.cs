using System;

public class BoardEvents {
    public static event Action OnShapeStopped;
    public static void ShapeStopped() {
        if (OnShapeStopped != null) {
            OnShapeStopped();
        }
    }

    public static event Action<int> OnLinesCleared;
    public static void ClearedLines(int numberOfLines) {
        if (OnLinesCleared != null) {
            OnLinesCleared(numberOfLines);
        }
    }
}
