using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemyController {

    [SerializeField]
    private float Speed = 3f;

    [SerializeField]
    private Transform GroundDectation;

    [SerializeField]
    private float Distance = 2f;

    [SerializeField]
    private LayerMask GroundMask;

    private bool _isMovingRight = true;
    private IPlayerController _playerController;

	void Update () {
        enemyPatrol();
	}

    private void enemyPatrol() {
        var move = Vector3.left * Speed * Time.deltaTime;
        transform.Translate(move);
        drawRay();

        // if the ray cast that is emitting from GroundDectation object does not hit the ground(cube)
        // the player would rotate in opposite directoin
        if (!Physics.Raycast(GroundDectation.position, Vector3.down, Distance, GroundMask)) {
            if (_isMovingRight) {
                transform.eulerAngles = new Vector3(0, -180f, 0);
                _isMovingRight = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _isMovingRight = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        // if it collide with player, destroy the player
        if (other.collider.tag == "Player") {
            _playerController = other.collider.GetComponent<IPlayerController>();
            _playerController.playerHealth();
        }
    }

    private void drawRay() {
        var down = GroundDectation.TransformDirection(Vector3.down) * Distance;
        Debug.DrawRay(GroundDectation.position, down, Color.green);
    }

    public void EnemyHealth() {
        destroyEnemy();
    }

    private void destroyEnemy() {
        Destroy(this.gameObject);
    }
}
