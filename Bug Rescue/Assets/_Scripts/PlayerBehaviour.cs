using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour, IPlayerController {
    
    [SerializeField]
    private float Speed = 3f;
    
    [SerializeField]
    private float jumpHeight = 10f;

    [SerializeField]
    private AudioClip PickUpClip;

    [SerializeField]
    private AudioClip JumpClip;

    [SerializeField]
    private AudioClip DeathClip;

    private Rigidbody _rbPlayer;

    [SerializeField]
    private Transform ParentTransform;

    private int _parentCount = 0;

    private ILeafController _leafController;
    private IEnemyController _enemyController;
    private IBugAnimContoller _bugAnimContoller;

    private IUIController _uiController;
    private IGameController _gameController;

    void Start () {
        _rbPlayer = GetComponent<Rigidbody>();
        _bugAnimContoller = GetComponent<IBugAnimContoller>();

        _uiController = GameObject.Find("UI_Manager").GetComponent<IUIController>();
        _gameController = GameObject.Find("GameManager").GetComponent<IGameController>();
	}
	
	void Update () {
		
	}

    private void FixedUpdate() {
        playerMovement();
    }

    // A funciton to define movement for player 
    private void playerMovement() {
        var horizontal = Input.GetAxis("Horizontal"); // gettting x-axis
        _bugAnimContoller.IdleAndWalk(horizontal);

        // this will let the player to move on x-axis
        _rbPlayer.velocity = new Vector3(-horizontal * Speed, _rbPlayer.velocity.y, 0);

        if (Mathf.Abs(_rbPlayer.velocity.y) > 2f) {
            _bugAnimContoller.InAir(true);
        } else {
            _bugAnimContoller.InAir(false);
        }

    }

    public void MoveUp() {
        AudioSource.PlayClipAtPoint(JumpClip, transform.position);
        _rbPlayer.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
    }


    public void playerHealth() {
        destroyPlayer();

    }

    public void PlayerDead() {
        GetComponent<CapsuleCollider>().isTrigger = true;
        _rbPlayer.useGravity = false;

        _bugAnimContoller.Dying(true);

        AudioSource.PlayClipAtPoint(DeathClip, transform.position);
        Camera.main.GetComponent<CameraFollow>().enabled = false; // just to make sure to disable this script so unity will not thrown any exception

        _uiController.GameOver();

        destroyPlayer();
    }

    private void destroyPlayer() {
       
        Destroy(this.gameObject, 2f);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Moving_Platform")
        {
            print("enter platform  :)" + other.collider.name);
            this.transform.parent = other.collider.transform;
            _parentCount++;        
        }
        if (other.collider.tag == "Enemy") {
            _enemyController = other.collider.GetComponent<IEnemyController>();
            _enemyController.Damage(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag == "Moving_Platform") {
            print("exit platform :(");
            if (_parentCount == 1) {
                this.transform.parent = ParentTransform;
                _parentCount = 0;
            }
            else
                _parentCount = 1;
		}
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Collectable") {
            _uiController.Collectable();
            AudioSource.PlayClipAtPoint(PickUpClip, other.transform.position);
            Destroy(other.gameObject);
        }

        if (other.tag == "Finish") {
            _gameController.StartNextScene();
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
