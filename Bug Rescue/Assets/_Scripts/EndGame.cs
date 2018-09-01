using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}


    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
