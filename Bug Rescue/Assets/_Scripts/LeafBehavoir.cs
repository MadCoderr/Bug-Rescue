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
    private Transform LeafEnd;

    [SerializeField]
    private float RotateSpeed = 5f;

    private Vector3 pos;

    private void Start() {
        pos = LeafPivot.eulerAngles;
    }

    public void BendUp() {
        LeafPivot.rotation = Quaternion.Slerp(LeafPivot.rotation, Quaternion.Euler(pos), Time.deltaTime);
    }

    public void BendDown() {
        if (Vector3.Distance(LeafEnd.position, PointA.position) >= 1f) {
            LeafPivot.transform.Rotate(-RotateSpeed * Time.deltaTime, 0, 0);
        }
  
    }

    public void ActivateParticle()
    {
        Particle.gameObject.SetActive(true);
    }

    public void DeactivateParticle()
    {
        Particle.gameObject.SetActive(false);
    }
}
