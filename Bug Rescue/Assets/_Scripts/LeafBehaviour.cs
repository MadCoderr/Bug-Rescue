using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehaviour : MonoBehaviour {

    [SerializeField]
    private float Increment = 15f;

    [SerializeField]
    private Transform LeafPivot;

    [SerializeField]
    private ParticleSystem Particle;

    private Transform _playerPos;
    private bool _isCollided = false;
    private bool _backToPos = false;
    private bool _isRight = false;
    private bool _isLeft = false;

    private float _distance;
    

	// Update is called once per frame
	void LateUpdate () {
        // if player is on top of leaf 
		if (_isCollided) {
            // calu the dist between lead  and player postion and on that bases it will bend
            _distance = Vector3.Distance(LeafPivot.position, _playerPos.position);

            // if player is moving in right dir add increment (i need to add another value because the dist value if to small for rotation)
            if (_isRight)
                LeafPivot.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, _distance + Increment), Time.deltaTime);

            // if player is moving in left dir sub increment (i need to add another value because the dist value if to small for rotation)
            else if (_isLeft) {
                var value = _distance - Increment;
                // i don't want the my leaf object rotate backward so i reset it and rotation on z is less than zero
                if (value < 0)
                    value = 0;

                LeafPivot.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, value), Time.deltaTime * 2f);
            }
                

        }
        // if player is not anymore on top of leave revert back leaf positoin to it's orignal position
        else if (_backToPos) {
            LeafPivot.rotation = Quaternion.Slerp(LeafPivot.rotation, Quaternion.identity, Time.deltaTime);
        }
	}

    public void activateParticle() {
        Particle.gameObject.SetActive(true);
    }


    private void OnCollisionStay(Collision other) {
        _backToPos = false;
        if (other.collider.tag == "Player") {
            _isCollided = true;
            _playerPos = other.collider.gameObject.transform;

            if (other.collider.GetComponent<PlayerBehaviour>().IS_LEFT) {
                _isLeft = true;
                _isRight = false;
            }
            else if (other.collider.GetComponent<PlayerBehaviour>().IS_RIGHT) {
                _isRight = true;
                _isLeft = false;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        _isCollided = false;
        _isRight = false;
        _isLeft = false;
        _backToPos = true;
    }
}
