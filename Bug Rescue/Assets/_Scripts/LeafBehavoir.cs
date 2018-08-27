using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehavoir : MonoBehaviour, ILeafController {

    [SerializeField]
    private ParticleSystem Particle;

    [SerializeField]
    private Transform LeafPivot;

    [SerializeField]
    private float RotateSpeed = 5f;

    public void BendLeft()
    {
            LeafPivot.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
    }

    public void BendRight()
    {
            LeafPivot.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }

    public void ActivateParticle()
    {
        Particle.gameObject.SetActive(true);
    }


}
