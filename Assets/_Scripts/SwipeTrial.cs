using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrial : MonoBehaviour {

	public GameObject trailPrefab;		//passing through the prefab
	GameObject thisTrail;				//instance created of the current line being drawn
	Vector2 startPos; 					//2D start position of where we clicked/touched
	Plane objPlane;						//plain plane :)

	private bool isSwipe;

	//me
	//Vector2 currPos;

	void Start(){

		//flat plane at the position of the swipe object and facing towards camera
		objPlane = new Plane (Camera.main.transform.forward * -1, this.transform.position);

		isSwipe = true;
	}
	
	// Update is called once per frame
	void Update () {

		if ( isSwipe ) {

			//when we touch the screen
			if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || Input.GetMouseButtonDown (0)) {

				//the instance of the line is created
				thisTrail = (GameObject)Instantiate (trailPrefab, this.transform.position, Quaternion.identity);

				//Ray based on position of the mouse
				Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				float rayDistance;

				if (objPlane.Raycast (mRay, out rayDistance))
				//record swipe object position -> used in the 2nd else if
				startPos = mRay.GetPoint (rayDistance);
			}

			//if there's been more than 1 touch in this screen and if first touch is moving, OR if left mouse button down
			else if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButton (0))) {

					//Ray based on position of the mouse
					Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
					float rayDistance;

					if (objPlane.Raycast (mRay, out rayDistance)) {
						//update swipe object position
						//moving the trail to that position
						thisTrail.transform.position = mRay.GetPoint (rayDistance);
						//print(mRay.GetPoint(rayDistance));

						//currPos = mRay.GetPoint (rayDistance); 
						//thisTrail.transform.position = currPos;

					}

				}

			//if distance between start position and final position is very small, destroy object (not a drawing)
			else if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp (0)) {

					if (Vector2.Distance (thisTrail.transform.position, startPos) < 0.1)								//2D
					Destroy (thisTrail);

			}
		}
	}

	public void Swiping(bool value){
		isSwipe = !value;
	}
}
