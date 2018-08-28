using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemyController {

    [SerializeField]
    private float Speed = 3f;

    private IPlayerController _playerController;
    private MovementBetweenPoints _movement;

    private void Start() {
        _movement = GetComponent<MovementBetweenPoints>();
    }

    void Update () {
        _movement.SPEED = Speed;
    }

    private void OnCollisionEnter(Collision other) {
        // if it collide with player, destroy the player
        if (other.collider.tag == "Player") {
            _playerController = other.collider.GetComponent<IPlayerController>();
            _playerController.playerHealth();
        }
    }



    public void EnemyHealth() {
        destroyEnemy();
    }

    private void destroyEnemy() {
        Destroy(this.gameObject);
    }
}
