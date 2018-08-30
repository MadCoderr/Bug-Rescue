public interface IPlayerController {
    void MoveUp();
    void playerHealth();
}

public interface IEnemyController {
    void EnemyHealth();
    void Damage(object gameObject);
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
    void BendDown();
    void BendUp();
    void ActivateParticle();
}

public interface IStickContoller {
    void BurnTheStick();
}

public interface IBugAnimContoller {
    void IdleAndWalk(float move);
    void Dying(bool check);
}