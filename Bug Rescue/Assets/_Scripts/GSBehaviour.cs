using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSBehaviour : MonoBehaviour {
    
    private Vector3 _startPos;
    private Transform _target;

	// Use this for initialization
	void Start () {
        _startPos = new Vector3(transform.position.x, -2.8f, transform.position.z);
        transform.position = _startPos;
	}
	
	// Update is called once per frame
	void Update () {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, 3.5f * Time.deltaTime);
	}

    public void setTarget(Transform target) {
        _target = target;
    }
}
