public interface IPlayerController {
    void MoveUp();
}

public interface IBridgeController {
    void openBridge();
    void closeBridge();
}

public interface ITrampolineController {
    void activateTrampoline();
    void disableTrampoline();
}