using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayerController {

    [SerializeField]
    private float Speed = 3f;

    private IBridgeController _bridgeContorller;
    private Rigidbody _rbPlayer;

    private float jumpHeight = 10f;

    void Start () {
        _rbPlayer = GetComponent<Rigidbody>();
        _bridgeContorller = GameObject.Find("Example_Bridge").GetComponent<IBridgeController>();
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

        // When user gives input of space We activate its script component to open the gate; (By default the gate is closed)
        if (Input.GetKey(KeyCode.Space)) {
            _bridgeContorller.openBridge();
        }
        else if (Input.GetKeyUp(KeyCode.Space)) {
            _bridgeContorller.closeBridge();
        }
    }

    public void MoveUp() {
        _rbPlayer.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
    }
}
