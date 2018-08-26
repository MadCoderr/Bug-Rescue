using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    private float Speed = 3f;

    [SerializeField]
    private Transform GroundDectation;

    [SerializeField]
    private float Distance = 2f;

    private bool _isMovingRight = true;
    private IPlayerController _playerController;
	
	void Update () {
        enemyPatrol();
	}

    private void enemyPatrol() {
        transform.Translate(-Vector3.right * Speed * Time.deltaTime);

        // if the ray cast that is emitting from GroundDectation object does not hit the ground(cube)
        // the player would rotate in opposite directoin
        if (!Physics.Raycast(GroundDectation.position, Vector3.down, Distance))
        {
            if (_isMovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180f, 0);
                _isMovingRight = false;
            }
            else
            {
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
}
