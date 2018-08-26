using System.Collections;
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
	
	void LateUpdate ()
	{
        // will follow the player postion smoothly.
		transform.position = Vector3.Lerp (transform.position, FollowTarget.position + OffSet, CamSpeed); 
	}
}
