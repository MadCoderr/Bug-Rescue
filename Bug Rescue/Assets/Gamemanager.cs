﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {

	public Image img;
	public float tim;

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	public void SceneLoad(int a)
	{
		//img.color += new Color (0, 0, 0, 1);
		SceneManager.LoadScene (a);

	}

	public void Quit()
	{
		Application.Quit ();
	}

    public static void LoadMenu() {
        SceneManager.LoadScene(0);
    }
}
