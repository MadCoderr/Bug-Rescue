using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAnimation : MonoBehaviour, IBugAnimContoller {

    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}

    public void IdleAndWalk(float move) {
        _animator.SetFloat("Speed", move);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            transform.eulerAngles = new Vector3(0, 90, 0);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            transform.eulerAngles = new Vector3(0, -90, 0);
    }

    public void Dying(bool check) {
        _animator.SetTrigger("Bug_Dead");
    }
}
