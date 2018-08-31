using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBettle : EnemyBehaviour {

    private Animator _animator;
    private MovementBetweenPoints _ref;
    private CapsuleCollider _collider;

    private void Start() {
        _animator = GetComponent<Animator>();
        _ref = GetComponent<MovementBetweenPoints>();
        _collider = GetComponent<CapsuleCollider>();
    }

    public override void EnemyHealth() {
        base.EnemyHealth();
        _collider.isTrigger = true;
        _ref.enabled = false;
        _animator.SetTrigger("Dead");
    }
}
