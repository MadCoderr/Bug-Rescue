public interface IPlayerController {
    void MoveUp();
    void playerHealth();
}

public interface IEnemyController {
    void EnemyHealth();
}

public interface IBridgeController {
    void openBridge();
    void closeBridge();
}

public interface ITrampolineController {
    void activateTrampoline();
    void disableTrampoline();
}

public interface ILeafController {
    void BendRight();
    void BendLeft();
    void ActivateParticle();
}