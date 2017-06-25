using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongPanelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find ("WrongPanel").SetActive(false);
	}
	public IEnumerator wrongPanelActivate(){
		gameObject.SetActive(true);       
		yield return new WaitForSeconds(0.3f);
		gameObject.SetActive(false);    
	}
}
