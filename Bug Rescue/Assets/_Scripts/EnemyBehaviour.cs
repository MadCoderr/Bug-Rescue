using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemyController {

    [SerializeField]
    private AudioClip DeathClip;

    private IPlayerController _playerController;
    private bool _isDead = false;

    public virtual void EnemyHealth() {
        destroyEnemy();
        _isDead = true;
    }

    public virtual void Damage(object gameObject) {
        if (!_isDead) {
            _playerController = ((GameObject)gameObject).GetComponent<IPlayerController>();
            _playerController.PlayerDead();
        }
    }

    private void destroyEnemy() {
        AudioSource.PlayClipAtPoint(DeathClip, transform.position);
        Destroy(this.gameObject, 2.2f);
    }

    
}
