using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBettle : EnemyBehaviour {

    private Animator _animator;
    private MovementBetweenPoints _ref;

    private void Start() {
        _animator = GetComponent<Animator>();
        _ref = GetComponent<MovementBetweenPoints>();
    }

    public override void EnemyHealth() {
        base.EnemyHealth();
        _ref.enabled = false;
        _animator.SetTrigger("Dead");
    }
}
