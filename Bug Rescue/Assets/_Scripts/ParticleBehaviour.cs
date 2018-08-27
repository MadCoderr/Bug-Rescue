using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour {

    private IEnemyController _enemyController;

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Enemy") {
            _enemyController = other.GetComponent<IEnemyController>();
            _enemyController.EnemyHealth();
            gameObject.SetActive(false);
        }
    }
}
