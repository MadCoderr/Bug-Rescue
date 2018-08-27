using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayerController {

    public bool IS_MOVING = false;
    public bool IS_RIGHT = false;
    public bool IS_LEFT = false;

    [SerializeField]
    private float Speed = 3f;
    
    [SerializeField]
    private float jumpHeight = 10f;


    private IBridgeController _bridgeContorller;
    private Rigidbody _rbPlayer;

    
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
        checkMovement(horizontal);

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


    public void playerHealth()
    {
        destroyPlayer();
    }

    private void checkMovement(float horizontal) {
        if (horizontal > 0)
        {
            IS_MOVING = true;
            IS_RIGHT = true;
            IS_LEFT = false;
        }
        else if (horizontal < 0)
        {
            IS_MOVING = true;
            IS_RIGHT = false;
            IS_LEFT = true;
        }
        else
        {
            IS_MOVING = false;
            IS_RIGHT = false;
            IS_LEFT = false;
        }

    }

    private void destroyPlayer() {
        Camera.main.GetComponent<CameraFollow>().enabled = false; // just to make sure to disable this script so unity will not thrown any exception
        Destroy(this.gameObject);
    }
}
