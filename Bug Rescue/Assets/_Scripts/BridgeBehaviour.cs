using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour, IBridgeController {

    private float _time = 0.01f;
    private float _maxTime = 0.1f;
    private float _openingTime;


	void Update () {
        // rotate the bridge, so its look like its opening
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, _time);
	}

    public void openBridge()
    {
        _openingTime += Time.deltaTime;
        if (_openingTime >= _maxTime) {
            this.enabled = true;
            _openingTime = 0;
        }
        
    }

    public void closeBridge()
    {
        _openingTime = 0;
    }
}
