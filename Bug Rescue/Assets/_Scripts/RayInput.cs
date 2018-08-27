using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayInput : MonoBehaviour {

    [SerializeField]
    private LayerMask TargetMask;

    [SerializeField]
    private float RayLength;

    private RaycastHit _hitInfo;
    private IBridgeController _bridgeController;
    private ITrampolineController _trampolineController;

    private string _colliderTag = "";

	void Start () {
        _bridgeController = GameObject.Find("Example_Bridge").GetComponent<IBridgeController>();
    }
	
	void Update () {
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hitInfo , RayLength, TargetMask)) {

                _colliderTag = _hitInfo.collider.tag;

                if (_hitInfo.collider.tag == "Bridge") {
                    _bridgeController.openBridge();
                }

                else if (_hitInfo.collider.tag == "Trampoline") {
                    _trampolineController = _hitInfo.collider.GetComponent<ITrampolineController>();
                    if (_trampolineController != null)
                        _trampolineController.activateTrampoline();
                }
                
                else if (_hitInfo.collider.tag == "Water_Drop") {
                    _hitInfo.collider.GetComponentInParent<LeafBehaviour>().activateParticle();
                }
            }
        } 
        // if player release the button the time will reset
        else if (Input.GetMouseButtonUp(0)) {
           if (_colliderTag.Length > 0) {
                if (_colliderTag == "Bridge")
                    _bridgeController.closeBridge();

                else if (_colliderTag == "Trampoline")
                    _trampolineController.disableTrampoline();
            }
        }
	}
}
