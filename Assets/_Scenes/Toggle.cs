using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {

	//is button pressed function
	public void Toggling(bool value){
		print (value);
		GameObject.Find ("Swipe").GetComponent<SwipeTrial> ().isSwipe = !value;
		GameObject.Find ("Cube").GetComponent<Spin> ().isSpin = value;
	}
}
