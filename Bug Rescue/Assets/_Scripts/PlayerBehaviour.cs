using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayerController {


    [SerializeField]
    private float Speed = 3f;
    
    [SerializeField]
    private float jumpHeight = 10f;

    private Rigidbody _rbPlayer;
    private Transform _tempTransform;


    private IBridgeController _bridgeContorller;
    private ILeafController _leafController;
    private IEnemyController _enemyController;

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


    public void playerHealth()
    {
        destroyPlayer();
    }

    private void destroyPlayer() {
        Camera.main.GetComponent<CameraFollow>().enabled = false; // just to make sure to disable this script so unity will not thrown any exception
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Moving_Platform") {
            _tempTransform = this.transform.parent;
            this.transform.parent = other.collider.transform; 
            print("enter platform  :)");
        }

        if (other.collider.tag == "Enemy") {
            _enemyController = other.collider.GetComponent<IEnemyController>();
            _enemyController.Damage(this.gameObject);
        }

        if (other.collider.tag == "Frog_Tongue") {
            _tempTransform = this.transform.parent;
            this.transform.parent = other.collider.transform.parent.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag == "Moving_Platform") {
            print("exit platform :(");
            this.transform.parent = _tempTransform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Left_Ref") {
            _leafController = other.GetComponentInParent<ILeafController>();
            _leafController.BendUp();
        }
        else if (other.tag == "Right_Ref") {
            _leafController = other.GetComponentInParent<ILeafController>();
            _leafController.BendDown();
        }
    }

}
