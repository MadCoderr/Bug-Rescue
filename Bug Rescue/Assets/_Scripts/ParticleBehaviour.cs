using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour {

    private IEnemyController _enemyController;
    private IStickContoller _stickController;


    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Enemy") {
            _enemyController = other.GetComponent<IEnemyController>();
            _enemyController.EnemyHealth();
            gameObject.SetActive(false);
        }

        if (other.tag == "Stick") {
            _stickController = other.GetComponent<IStickContoller>();
            _stickController.BurnTheStick();
        }
    }

}
