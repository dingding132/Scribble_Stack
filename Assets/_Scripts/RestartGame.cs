using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
	public Button restartButton;
	// Use this for initialization
	void Start () {
		restartButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void restartGameButton(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		//reload timer
	}
}
