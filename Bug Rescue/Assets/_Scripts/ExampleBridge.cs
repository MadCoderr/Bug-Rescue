using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBridge : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//OpenGate ();
		transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.identity,0.01f);  //Code to open thwe bridge.
	}
}

