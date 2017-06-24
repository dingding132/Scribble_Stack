using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			//Button is pressed, fetch text of button
			Text buttontext = GetComponentInChildren<Text> ();

			//fetch secret word of button manager
			GameObject Manager = GameObject.Find ("_Manager");
			MainController controller = Manager.GetComponent<MainController> ();
			//compare to check if right word
			if (buttontext.text.Equals(controller.SecretWord)){
				//call right function in main controller
				controller.control = MainController.choiceOutcome.RIGHT;
				Debug.Log("right!");
			}	
			else{
				//call wrong function in main controller
				controller.control = MainController.choiceOutcome.WRONG;
				Debug.Log ("wrong!");
			}	
		}

	}
}
