using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayerController {

    public bool IS_MOVING = false;

    [SerializeField]
    private float Speed = 3f;
    
    [SerializeField]
    private float jumpHeight = 10f;


    private IBridgeController _bridgeContorller;
    private Rigidbody _rbPlayer;

    private ILeafController _leafController;

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
        if (horizontal != 0)
        {
            IS_MOVING = true;
        } else {
            IS_MOVING = false;
        }

    }

    private void destroyPlayer() {
        Camera.main.GetComponent<CameraFollow>().enabled = false; // just to make sure to disable this script so unity will not thrown any exception
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Left_Ref") {
            _leafController = other.GetComponentInParent<ILeafController>();
            _leafController.BendLeft();
        }
        else if (other.tag == "Right_Ref") {
            _leafController = other.GetComponentInParent<ILeafController>();
            _leafController.BendRight();
        }
    }

}
