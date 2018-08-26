using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour, ITrampolineController {

    [SerializeField]
    private ParticleSystem Particle;

    private CapsuleCollider _collider;

    private bool _isActive = false;
    private float _maxTime = 2f;
    private float _activateTime;

    private IPlayerController _playerController;

    void Start () {
        _collider = GetComponent<CapsuleCollider>();  
	}
	
	
	void Update () {
		
	}

    //this method, will be called whenever user is being pushing on trampoline
    // and will trigger the requred stuff when _activate time >= 2second
    public void activateTrampoline()
    {
        _activateTime += Time.deltaTime;
        if (_activateTime >= _maxTime) {
            _isActive = true;
            _collider.isTrigger = false;
            Particle.gameObject.SetActive(true);
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
                print("collide with player");
                _playerController = other.gameObject.GetComponent<IPlayerController>();
                _playerController.MoveUp();
            }
        }
    }


}
