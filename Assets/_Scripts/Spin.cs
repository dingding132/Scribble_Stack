using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{

    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;

	private bool isSpin;

    void Start()
    {
        _sensitivity = 0.4f;
        _rotation = Vector3.zero;

		isSpin = false;
    }

    void Update()
    {

		//if toggle pressed is true: do this
		if(isSpin){

			if (_isRotating) {
				// offset
				_mouseOffset = (Input.mousePosition - _mouseReference);

				// apply rotation
				_rotation.z = -(_mouseOffset.x + _mouseOffset.z) * _sensitivity;

				// rotate
				transform.Rotate (_rotation);

				// store mouse
				_mouseReference = Input.mousePosition;
			}
		}
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }

	public void Spinning(bool value){
		isSpin = value;
	}
		
}