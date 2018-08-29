using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBehaivour : MonoBehaviour, IStickContoller {

    [SerializeField]
    private Transform RightStick;

    [SerializeField]
    private float RollSpeed = 2f;

    private Animator _animator;
    private BoxCollider _collider;

    private void Start() {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
    }

    private void Update() {
        if (transform.localScale.magnitude == 0) {
            // destroyStick();
            _collider.enabled = false;
            _animator.enabled = false;
            rollTheRog();
        }
    }

    private void rollTheRog() {
        RightStick.Rotate(0, 0, -(RollSpeed * Time.deltaTime) * 50f, Space.World);
        RightStick.Translate(Vector3.right * RollSpeed * Time.deltaTime, Space.World);
    }

    public void BurnTheStick() {
        _animator.enabled = true;
    }

    private void destroyStick() {
        Destroy(this.gameObject);
    }
}
