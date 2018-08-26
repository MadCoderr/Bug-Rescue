using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private float Speed = 3f;

    private Rigidbody _rbPlayer;

	public ExampleBridge refer;

	void Start () {
        _rbPlayer = GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

    private void FixedUpdate()
    {
        playerMovement();
    }

    // A funciton to define movement for player 
    private void playerMovement() {
        var horizontal = Input.GetAxis("Horizontal"); // gettting x-axis
        // this will let the player to move on x-axis
        _rbPlayer.velocity = new Vector3(-horizontal * Speed, _rbPlayer.velocity.y, 0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			refer.GetComponent<ExampleBridge> ().enabled = true;  // When user gives input of space We activate its script component to open the gate;(By default the gate is closed)
		}
    }

}
