using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

//	public Transform posA,posB; // The points between the enemy moves
//	private Vector3 target; //To get the point enemy should move towards anytime.
//	public float speed;
//	private Vector3 move;
//
//	void Start()
//	{
//		target = posA.position; // Initializing Random Point
//	}
//
//	void Update()
//	{
//		move= Vector3.left * speed * Time.deltaTime;
//		Debug.Log (Mathf.Abs(transform.position.x-posA.position.x)+"PosA");
//		Debug.Log (Mathf.Abs(transform.position.x-posB.position.x)+"PosB");
//		//Debug.Log (Vector3.Distance (target, transform.position));
//		if (Mathf.Abs(transform.position.x-posA.position.x)<0.5f) 
//		{
//			//target = posB.position;
//			speed*=-1;
//			Debug.Log("DO");
//
//		}
//
//		if (Mathf.Abs(transform.position.x-posB.position.x)<0.5f) 
//		{
//			//target = posA.position;
//			Debug.Log("DONT");
//			speed*=-1;
//
//		}
//
//	//	transform.position =
//		transform.Translate(move);
//	}

	[SerializeField] private float moveSpeed;
	[SerializeField] private GameObject pointA; //Position A
	[SerializeField] private GameObject pointB; //Position B
	[SerializeField] private bool reverseMove = false;
	private Transform objectToUse;
	[SerializeField] private bool moveThisObject = false;
	private float startTime;
	private float journeyLength;
	private float distCovered;
	private float fracJourney;
	void Start()
	{
		//startTime = Time.time;
		//if (moveThisObject)
		//{
		//	objectToUse = transform;
		//}
		objectToUse = transform;
		//.Log (moveSpeed);
		//moveSpeed = moveSpeed / 1000f;
		//Debug.Log (moveSpeed);
	}
	void Update()
	{
		///distCovered = (Time.time - startTime) * moveSpeed;
	//	fracJourney = distCovered / journeyLength;
		if (reverseMove)
		{
			objectToUse.Translate(new Vector3 (moveSpeed,0,0));
		}
		else
		{
			objectToUse.Translate(new Vector3 (moveSpeed,0,0));
		}
		if ((Vector3.Distance(objectToUse.position, pointB.transform.position) < 1f || Vector3.Distance(objectToUse.position, pointA.transform.position) < 1f)) //Checks if the object has travelled to one of the points
		{
			if (reverseMove)
			{
				reverseMove = false;
				moveSpeed *= -1f;
			}
			else
			{
				moveSpeed *= -1f;
				reverseMove = true;
			}
			startTime = Time.time;
		}
	}
}
