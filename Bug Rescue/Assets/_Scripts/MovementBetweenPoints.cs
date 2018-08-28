using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBetweenPoints : MonoBehaviour {

    [SerializeField]
    private Transform PointA;

    [SerializeField]
    private Transform PointB;

    [SerializeField]
    private float Distance = 1f;

    public float SPEED;

    [SerializeField]
    private Transform TargetObject;

    [SerializeField]
    private bool Rotation = false;

    private bool _movingRight = true;

	void Update () {
        if (Rotation) {
            moveAndRotate();
        } else {
            move();
        }
    }

    private void moveAndRotate() {
        var move = Vector3.left * SPEED * Time.deltaTime;
        TargetObject.Translate(move);

        if (Vector3.Distance(TargetObject.transform.position, PointB.transform.position) < Distance) {
            TargetObject.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (Vector3.Distance(TargetObject.transform.position, PointA.transform.position) < Distance) {
            TargetObject.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void move() {

        if (_movingRight) {
            TargetObject.Translate(Vector3.left * SPEED * Time.deltaTime);
        }
        else {
            TargetObject.Translate(Vector3.right * SPEED * Time.deltaTime);
        }

        if (Vector3.Distance(TargetObject.transform.position, PointB.transform.position) < Distance) {
            _movingRight = false;
        }
        else if (Vector3.Distance(TargetObject.transform.position, PointA.transform.position) < Distance) {
            _movingRight = true;
        }

    }
}
