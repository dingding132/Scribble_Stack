﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
	public Button restartButton;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}
	public void restartGameButton(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		//reload timer
	}
}