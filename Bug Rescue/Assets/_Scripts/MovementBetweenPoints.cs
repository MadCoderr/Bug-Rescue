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

    [SerializeField]
    private bool UpDown = false;

    [SerializeField]
    private float WaitTime;
    
    private float _time;
    private bool _reachedToA = true;
    private Vector3 _pointB;
    private Vector3 _pointA;

    private void Start() {
        _time = 0f;

        if (UpDown) {
            _pointB = Vector3.up;
            _pointA = Vector3.down;
        } else {
            _pointB = Vector3.left;
            _pointA = Vector3.right;
        }

    }

    void Update () {
        if (_time <= 0) {
            if (Rotation) {
                moveAndRotate();
            }
            else {
                move();
            }
        } else {
            _time -= Time.deltaTime;
        }
    }

    private void moveAndRotate() {
       // var move = Vector3.left * SPEED * Time.deltaTime;
        var move = _pointB * SPEED * Time.deltaTime;
        TargetObject.Translate(move);

        if (Vector3.Distance(TargetObject.transform.position, PointB.transform.position) < Distance) {
            TargetObject.eulerAngles = new Vector3(0, -180f, 0);
            _time = WaitTime;
        }
        else if (Vector3.Distance(TargetObject.transform.position, PointA.transform.position) < Distance) {
            TargetObject.eulerAngles = new Vector3(0, 0, 0);
            _time = WaitTime;
        }
    }

    private void move() {

        if (_reachedToA) {
           // TargetObject.Translate(Vector3.left * SPEED * Time.deltaTime);
            TargetObject.Translate(_pointB * SPEED * Time.deltaTime);
        }
        else {
           // TargetObject.Translate(Vector3.right * SPEED * Time.deltaTime);
            TargetObject.Translate(_pointA * SPEED * Time.deltaTime);
        }

        if (Vector3.Distance(TargetObject.transform.position, PointB.transform.position) < Distance) {
            _reachedToA = false;
            _time = WaitTime;
        }
        else if (Vector3.Distance(TargetObject.transform.position, PointA.transform.position) < Distance) {
            _reachedToA = true;
            _time = WaitTime;
        }

    }
}
