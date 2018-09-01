using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDeath : MonoBehaviour {

	private GameObject player;
    private IPlayerController _playerController;
    
	void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Player") {
            _playerController = other.gameObject.GetComponent<IPlayerController>();
            _playerController.PlayerDead();
		}
	}
}
