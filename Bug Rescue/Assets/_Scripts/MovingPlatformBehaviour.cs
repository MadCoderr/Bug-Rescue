using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour {

    [SerializeField]
    private Transform PointA;

    [SerializeField]
    private Transform PointB;

    [SerializeField]
    [Range(0f, 1f)]
    private float LerpPercent = 0.5f; // to be in the middle of both points


    void Update () {
        transform.position = Vector3.Lerp(PointA.position, PointB.position, (Mathf.Sin(LerpPercent * Time.time) + 1f) / 2.0f);

    }
}
