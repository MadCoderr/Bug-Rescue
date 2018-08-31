using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBettle : EnemyBehaviour {

    [SerializeField]
    private GameObject GraveStrone;

    private Animator _animator;
    private MovementBetweenPoints _ref;
    private CapsuleCollider _collider;

    private bool _isInstantiate = false;

    private void Start() {
        _animator = GetComponent<Animator>();
        _ref = GetComponent<MovementBetweenPoints>();
        _collider = GetComponent<CapsuleCollider>();
    }

    public void Update() {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Dying")) {
           // showGraveStone();
        }
    }

    public override void EnemyHealth() {
        base.EnemyHealth();
        _collider.isTrigger = true;
        _ref.enabled = false;
        _animator.SetTrigger("Dead");
        showGraveStone();
    }

    private void showGraveStone () {
        if (!_isInstantiate) {
            var clone = Instantiate(GraveStrone, transform.position, Quaternion.Euler(-89.98f, 0, 0)) as GameObject;
            clone.GetComponent<GSBehaviour>().setTarget(this.transform);
            _isInstantiate = true;
        }
            
    }
}
