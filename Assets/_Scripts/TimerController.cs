using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	public Text timerText;
	private const float MAXTIMER = 180;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float t = MAXTIMER - Time.timeSinceLevelLoad;
		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f2");
		timerText.text = minutes + ":" + seconds;

		//if timer reaches end, game over
		if (t <= 0) {
			timerText.text = "0:00";
			GameObject Manager = GameObject.Find ("_Manager");
			MainController controller = Manager.GetComponent<MainController> ();
			controller.endGame();
		}
	}
}
