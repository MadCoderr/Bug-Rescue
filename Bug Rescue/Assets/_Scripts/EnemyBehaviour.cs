using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemyController {


    private IPlayerController _playerController;

    public virtual void EnemyHealth() {
        destroyEnemy();
    }

    public virtual void Damage(object gameObject) {
        _playerController = ((GameObject)gameObject).GetComponent<IPlayerController>();
        _playerController.playerHealth();
    }

    private void destroyEnemy() {
        Destroy(this.gameObject, 2f);
    }

    
}
