﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
	private Transform FollowTarget;

	[SerializeField]
	private float CamSpeed = 0.5f;

    [SerializeField]
    private Vector3 OffSet;

	void Start()
	{
		OffSet = new Vector3 (0, 4, 10);
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
      //  transform.position = FollowTarget.position + OffSet;
		transform.position = Vector3.Lerp (transform.position, FollowTarget.position + OffSet, CamSpeed);  //just to smooth.
		//transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}
}
