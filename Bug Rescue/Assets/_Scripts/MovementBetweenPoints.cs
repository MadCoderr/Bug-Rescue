using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBetweenPoints : MonoBehaviour {

    [SerializeField]
    private Transform PointA;

    [SerializeField]
    private Transform PointB;

    public float SPEED;

    [SerializeField]
    private Transform TargetObject;
    
	void Update () {
        var move = Vector3.left * SPEED * Time.deltaTime;
        TargetObject.Translate(move);

        if (Vector3.Distance(TargetObject.transform.position, PointB.transform.position) < 1f)
        {
            TargetObject.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (Vector3.Distance(TargetObject.transform.position, PointA.transform.position) < 1f)
        {
            TargetObject.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
