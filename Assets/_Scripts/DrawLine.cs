using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DrawLine : MonoBehaviour
{
	private LineRenderer line;
	private bool isMousePressed;
	public List<Vector3> pointsList;
	private Vector3 mousePos;

	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	//    -----------------------------------    
	void Start ()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer> ();
		line.material = new Material (Shader.Find ("Particles/Additive"));
		line.SetVertexCount (0);
		line.SetWidth (0.1f, 0.1f);
		line.SetColors (Color.yellow, Color.yellow);
		line.useWorldSpace = true;    
		isMousePressed = false;
		pointsList = new List<Vector3> ();
		//        renderer.material.SetTextureOffset(
		if (Input.GetMouseButtonDown (0)) {
			isMousePressed = true;
			line.SetVertexCount (0);
			pointsList.RemoveRange (0, pointsList.Count);
			line.SetColors (Color.yellow, Color.yellow);
		}
	}
	//    -----------------------------------    
	void Update ()
	{
		// If mouse button down, remove old line and set its color to green
		if (Input.GetMouseButtonUp (0)) {
			isMousePressed = false;
			//GetComponent<DrawLine>().enabled = false;
		}
		// Drawing line when mouse is moving(presses)
		if (isMousePressed) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			if (!pointsList.Contains (mousePos)) {
				pointsList.Add (mousePos);
				line.SetVertexCount (pointsList.Count);
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
			}
		}
	}
}