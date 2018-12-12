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
    public Animator animator;
    public Animator HPAnimator;
    [Header("Jump")]
    public float jumpHeight = 2;
    int DoubleJumps = 1;
    int dJumpCounter = 0;

    [Header("Health")]

    public int HP = 5;
    public bool invulnerable = false;

    /*[Header("Lock System")]
    public bool isTargeting = false;
    public Transform enemyPos;
    GameObject enemyToTarget;

    public float distanceBetweenTarget;
    */

    [Header("Weapon Switching")]
    public GameObject gun;
    public GameObject shotgun;
    
    Transform cameraT;
    CharacterController controller;

    bool godMode;
    
  
   void Awake ()
    {
        //PlayerPrefs.SetInt("HP",6);
       // int HP = PlayerPrefs.GetInt("HP", 0);
       //DontDestroyOnLoad(this.gameObject);
       
    }

    void Start ()
    {
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
       // enemyToTarget = GameObject.FindGameObjectWithTag("Enemy");
       // enemyPos = enemyToTarget.transform;
    }
	
	private void Update ()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("isJumping");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z) && !invulnerable)
        {   
            Damage();
        }

        

        if (HP <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.gameObject.SetActive(true);
            shotgun.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.gameObject.SetActive(false);
            shotgun.gameObject.SetActive(true);
        }


       // LookAt();
        /*if(distanceBetweenTarget <= 60 && Input.GetKeyDown(KeyCode.Q) && enemyPos != null)
        {
           isTargeting =! isTargeting;
        }
        */
        
        if (Input.GetKeyDown(KeyCode.F10))
        {
            godMode =! godMode;
            GodMode();
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

        animator.SetFloat("Speed", speed);
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

    public IEnumerator Damage()
    {
        if(invulnerable == false)
        {
            
            HP --;
            /* invulnerable = true;
             yield return new WaitForSeconds(1);
             invulnerable = false;
             */
            HPAnimator.SetTrigger("Damaged");
        }
        
        yield return null;
    }

   /*  void LookAt()
    {
        if(enemyPos != null)
        {
            distanceBetweenTarget = Vector3.Distance(transform.position, enemyPos.position);
        }

        if(isTargeting)
        {
            Debug.Log("targeting");
           Vector3 rotation = new Vector3(enemyPos.position.x, transform.position.y, enemyPos.transform.position.z);
       
           transform.LookAt(rotation);

           //transform.RotateAround(target.transform.position, Vector3.up, Vector3.Distance(target.transform.position, targetfound.transform.position));
        }
        
    }
    */

    void GodMode()
    {
        if(godMode == true)
        {
            walkSpeed = 12;
            invulnerable = true;
            jumpHeight = 20;
           
        }

        if (godMode == false)
        {
            walkSpeed = 6;
            invulnerable = false;
            jumpHeight = 2;
        }
    }

}
