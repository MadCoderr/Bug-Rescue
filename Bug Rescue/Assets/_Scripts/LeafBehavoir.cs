using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehavoir : MonoBehaviour, ILeafController {

    [SerializeField]
    private Transform PointA;

    [SerializeField]
    private Transform PointB;

    [SerializeField]
    private ParticleSystem Particle;

    [SerializeField]
	private Transform LeafPivot;

    [SerializeField]
    private float RotateSpeed = 5f;

    private float _maxRotation = 30f;
    private bool _reachedToMax = false;
    private bool _reachedToMin = false;

    public void BendLeft()
    {
        // 3.564867
        print("distance: " + Vector3.Distance(transform.position, PointB.position));
        if (Vector3.Distance(transform.position, PointB.position) >= 3.564867f) 
            LeafPivot.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
    }

    public void BendRight()
    {
       // print("distance: " + Vector3.Distance(transform.position, PointA.position));
        if (Vector3.Distance(transform.position, PointA.position) >= 3.53f)
                 LeafPivot.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }

    public void ActivateParticle()
    {
        Particle.gameObject.SetActive(true);
    }


}
