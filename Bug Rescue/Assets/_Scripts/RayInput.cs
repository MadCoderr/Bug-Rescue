using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayInput : MonoBehaviour {

    [SerializeField]
    private LayerMask TargetMask;

    [SerializeField]
    private float RayLength;

    private float _maxTime = 2f; // 2 second
    private float _time;


    private RaycastHit _hitInfo;
    private IBridgeController _bridgeController;

	void Start () {
        _bridgeController = GameObject.Find("Example_Bridge").GetComponent<IBridgeController>();
    }
	
	void Update () {
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hitInfo , RayLength, TargetMask)) {
                Debug.Log("ray hit: " + _hitInfo.collider.name);

                _time += Time.deltaTime; // adding time 
                print("time: " + _time);

                if (_time >= _maxTime) { // if time reach to 2 second open the gate
                    _bridgeController.openBridge(true);
                    _time = 0;
                }
                    
            }
        } 
        // if player release the button the time will reset
        else if (Input.GetMouseButtonUp(0)) {
            _time = 0;
            print("time is: " + _time);
        }
	}
}
