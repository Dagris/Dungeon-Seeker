using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool lockCursor;
	public float MouseSensitivity = 10;
	public Transform target;
	public float PlayerDistance = 10;
    public Vector2 CameraLimit = new Vector2 (-40, 85);

    public float rotationSmoothTime = .13f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float y;
	float x;
    
    void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
	
	void LateUpdate () 
	{
		y += Input.GetAxis("Mouse X") * MouseSensitivity;
		x -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        
        x = Mathf.Clamp(x, CameraLimit.x , CameraLimit.y);
        

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(x, y), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;	

		transform.position = target.position - transform.forward * PlayerDistance;		
	}
}
