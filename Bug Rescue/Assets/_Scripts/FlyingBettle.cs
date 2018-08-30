using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBettle : EnemyBehaviour {

    private Animator _animator;
    private MovementBetweenPoints _ref;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _ref = GetComponent<MovementBetweenPoints>();
	}

    public override void EnemyHealth() {
        base.EnemyHealth();
        _ref.enabled = false;
        _animator.SetTrigger("Dead");
    }

}
