﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool lockCursor;
	public float MouseSensitivity = 10;
	public Transform target;
	public float PlayerDistance = 10;
    public Vector2 CameraLimit = new Vector2 (-40, 85);

    public float rotationSmoothTime = 8f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    
    float yaw;
	float pitch;

   

    [Header("Collision Vars")]
    public bool changeTransparency = true;
    public SkinnedMeshRenderer targetRenderer;

    [Header("Speeds")]
    public float moveSpeed = 5;
    public float returnSpeed = 9;
    public float wallPush = 0.7f;

    [Header("Distances")]
    public float closestDistanceToPlayer = 2;
    public float evenCloserDistanceToPlayer = 1;

    [Header("Mask")]
    public LayerMask collisionMask;

    private bool pitchLock = false;


    public Transform enemyLockOn;
    public bool targetEnemy = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused == false)
        {

            lockCursor = true;

        }
        if (PauseMenu.GameIsPaused == true)
        {

            lockCursor = false;

        }

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        if(lockCursor == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

      /*  LockOn();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetEnemy =! targetEnemy;
        }
       
        */
    }
	
	void LateUpdate () 
	{
        
             //transform.position = target.position - transform.forward * PlayerDistance;
            CollisionCheck(target.position - transform.forward * PlayerDistance);
            WallCheck();

             if (!pitchLock)
            {
            yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;
            pitch = Mathf.Clamp(pitch, CameraLimit.x, CameraLimit.y);
            //currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        }

            else
            {   
            yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
            pitch = CameraLimit.y;
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            //currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
        }
             // currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            transform.eulerAngles = currentRotation;

            Vector3 e = transform.eulerAngles;
            e.x = 0;
        
       
        

       /* if(targetEnemy == true)
        {
            LockOn();
            CollisionCheck(target.position - transform.forward * PlayerDistance);
            WallCheck();

            if (!pitchLock)
            {
            yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;
            pitch = Mathf.Clamp(pitch, CameraLimit.x, CameraLimit.y);
            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
            }

            else
            {
            yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
            pitch = CameraLimit.y;

            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
            }
            // currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            transform.eulerAngles = currentRotation;

           
        }
        */
	}


    private void WallCheck()
    {
        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;

        if(Physics.SphereCast (ray, 0.5f, out hit, 0.7f, collisionMask))
        {
            pitchLock = true;
        }

        else
        {
            pitchLock = false;
        }
    }



    private void CollisionCheck (Vector3 retPoint)
    {
        RaycastHit hit;

        if(Physics.Linecast(target.position, retPoint, out hit, collisionMask))
        {
            Vector3 norm = hit.normal * wallPush;
            Vector3 p = hit.point + norm;

            TransparencyCheck();

            if(Vector3.Distance(Vector3.Lerp(transform.position,p,moveSpeed*Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
            {

            }

            else
            {
                transform.position = Vector3.Lerp (transform.position, p, moveSpeed * Time.deltaTime);
            }

            return;
        }

        FullTransparency();

        transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
        pitchLock = false;
    }


    private void TransparencyCheck()
    {
        if(changeTransparency)
        {
            if (Vector3.Distance (transform.position, target.position) <= closestDistanceToPlayer)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;
            }

            else
            {
                if(targetRenderer.sharedMaterial.color.a <= 0.99f)
                {
                    Color temp = targetRenderer.sharedMaterial.color;
                    temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                    targetRenderer.sharedMaterial.color = temp;
                }
            }
        }
    }

    private void FullTransparency()
    {
        if(changeTransparency)
        {
            if (targetRenderer.sharedMaterial.color.a <= 0.99f)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;
            }
        }
    }

  /*  void LockOn()
    {
        if(targetEnemy==true)
        {
            transform.LookAt(enemyLockOn);
        }
    }

    */
}
