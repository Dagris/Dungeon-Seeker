using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Header("Move ")]
    public float walkSpeed = 6;
    public float SmoothTime = 0.2f;
    float SmoothVelocity;
    public float gravity = -12;
    float velocityY;

    [Header("Jump")]
    public float jumpHeight = 1;
    int DoubleJumps = 1;
    int dJumpCounter = 0;

    [Header("Health")]

    public int HP = 3;
    public bool invulnerable = false;

    Transform cameraT;
    CharacterController controller;

    void Start ()
    {
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        HP = 3;
	}
	
   
    
	void Update ()
    {

        Move();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z) && !invulnerable)
        {
            Damage();
            /*invulnerable = true;
            yield return new WaitForSeconds(3);
            invulnerable = false;*/
        }

        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref SmoothVelocity, SmoothTime);
        }

        float speed = walkSpeed * inputDir.magnitude;

        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * speed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        speed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }


    void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
            dJumpCounter = 0;
        }


        if (!controller.isGrounded && dJumpCounter < DoubleJumps)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
            dJumpCounter++;
        }
    }

    void Damage()
    {
        HP --;
       
    }

}
