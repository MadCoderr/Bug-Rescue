using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour, ITrampolineController {

    [SerializeField]
    private GameObject ParticleSystem;

    private CapsuleCollider _collider;
    private Animator _animator;

    private bool _isActive = false;
    private float _maxTime = 2f;
    private float _activateTime;
    
    private IPlayerController _playerController;

    void Start () {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider>();
        _collider.center = new Vector3(0, 9f, 0); 
	}

    //this method, will be called whenever user is being pushing on trampoline
    // and will trigger the requred stuff when _activate time >= 2second
    public void activateTrampoline()
    {
        _activateTime += Time.deltaTime;
        if (_activateTime >= _maxTime) {
            _isActive = true;
            _animator.SetTrigger("Open");
            _collider.isTrigger = false;
            _collider.center = new Vector3(0, 7.83f, 0);
            ParticleSystem.SetActive(true);
        }
    }

    // this method will be called when user let go of mouse input when clicking on trampoline
    // and will reset the time for _activateTime
    public void disableTrampoline()
    {
        _activateTime = 0;
    }


    private void OnCollisionEnter(Collision other) {
        if (_isActive)
        {
            if (other.collider.tag == "Player")
            {
                _playerController = other.gameObject.GetComponent<IPlayerController>();
                _playerController.MoveUp();
            }
        }
    }


}
