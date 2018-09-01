using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDeath : MonoBehaviour {

	private GameObject player;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") 
		{
			player.GetComponent<PlayerBehaviour> ().playerHealth ();
		}
	}
}
