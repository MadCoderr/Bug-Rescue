using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour, IBridgeController {

    private float _time = 0.01f;
    
	void Update () {
        // rotate the bridge, so its look like its opening
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, _time);
	}

    public void openBridge(bool openIt)
    {
        this.enabled = openIt;
    }

}
