using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActions : MonoBehaviour {

	public void StartGame(string sceneName){
		Application.LoadLevel (sceneName);
	}
}
