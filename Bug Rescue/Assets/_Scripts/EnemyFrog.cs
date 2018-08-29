using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : EnemyBehaviour {

    [SerializeField]
    private Transform Pivot;
    [SerializeField]
    private float ScaleSpeed;

    private bool _isZero = false;
    private float _incrment = 0.01f;
    
    public void Update() {
        if (_isZero) {
            Pivot.localScale += new Vector3(0, 0, _incrment * Time.deltaTime * ScaleSpeed);
        }
        else
        {
            
            Pivot.localScale -= new Vector3(0, 0, _incrment * Time.deltaTime * ScaleSpeed * 2);
            if (Pivot.localScale.z > 0 && Pivot.localScale.z < 0.2)
            {
                _isZero = true;
            }
        }
            
        if (Pivot.localScale.z >= 1f) {
            _isZero = false;
        }
 
    }

}
