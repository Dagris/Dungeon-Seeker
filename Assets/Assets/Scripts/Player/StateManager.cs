using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace State
{
    public class StateManager : MonoBehaviour
    {
        [Header("Init")]
        public GameObject activeModel;

        [Header("Inputs")]
        public float vertical;
        public float horizontal;
        public float moveAmount;
        public Vector3 moveDir;
        public bool rt, rb, lt, lb, b, a, y, x;

        [Header("Stats")]
        public float moveSpeed = 2;
        //public float runSpeed = 3.5f;
        public float rotateSpeed = 5;
        public float toGround = 0.5f;

        [Header("Jump")]
        public float jumpHeight;
        int DoubleJumps = 1;
        int dJumpCounter = 0;

        [Header("States")]
        public bool onGround = true;
        public bool lockOn;
        public bool canMove;

        [Header("Other")]
        public EnemyTarget lockOnTarget;
        public Transform lockOnTransform;
        public float idlePlus;
        public bool god = false;
        public Image targetImg;
        public Camera cam;

        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public Rigidbody rigid;
        [HideInInspector]
        public Collider controllerCollider;
        [HideInInspector]
        public float delta;
        [HideInInspector]
        public LayerMask ignoreLayers;


        public void Init()
        {
            SetUpAnimator();
            rigid = GetComponent<Rigidbody>();
            rigid.angularDrag = 999;
            rigid.drag = 4;
            rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            
            gameObject.layer = 9;
            ignoreLayers = ~(1 << 11);
            anim = gameObject.GetComponentInChildren<Animator>();
            anim.SetBool("onGround", true);
            //targetImg.enabled = false;
        }
        
        void SetUpAnimator()
        {
            if (activeModel == null)
            {
                anim = GetComponentInChildren<Animator>();
                if (anim == null)
                {
                    Debug.Log("No model found");
                }
                else
                {
                    activeModel = anim.gameObject;
                }
            }

            if (anim == null)
            {
                anim = activeModel.GetComponent<Animator>();
            }
        }

        void Update()
        {
            if(moveAmount == 0)
            {
                idlePlus++;
            }

            else
            {
                idlePlus = 0;
            }

            if(idlePlus >= 770)
            {
                idlePlus = 0;
            }

            GodMode();
            if(Input.GetKeyDown(KeyCode.F10))
            {
                god = !god;
            }

            anim.SetFloat("idle+", idlePlus);


            if (lockOn == false)
            {
                targetImg.enabled = false;
            }

            else
            {
                targetImg.enabled = true;
                TargetImg();
            }

            //TargetImg();
        }

        public void FixedTick(float d) //movimiento
        {
            delta = d;

            rigid.drag = (moveAmount > 0 || onGround == false) ? 0 : 4;
            
            float targetSpeed = moveSpeed;

            //rigid.velocity = moveDir * (targetSpeed * moveAmount);

           if(onGround)
            {
                rigid.velocity = moveDir * (targetSpeed * moveAmount);
            }

           /* else
            {
                rigid.velocity = moveDir; //* (targetSpeed * moveAmount);
            }
            
            */
            Vector3 targetDir = (lockOn == false) ? moveDir : (lockOnTransform != null) ? lockOnTransform.transform.position - transform.position: moveDir;
            targetDir.y = 0;
            if (targetDir == Vector3.zero)
            {
                targetDir = transform.forward;
            }
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, delta * moveAmount * rotateSpeed);
            transform.rotation = targetRotation;



            

            //anim.SetBool("lockOn", lockOn);

            if(lockOn == false)
            {
                HandleMovementAnimations();
            }
            else
            {
                HandleLockOnAnimations(moveDir);
            }
        }

        public void DetectAction()
        {
            if(rb == false && rt == false && lt == false == lb == false)
            {
                return;
            }
        }

        public void Tick(float d)
        {
            delta = d;
            onGround = OnGround();
            anim.SetBool("onGround", onGround);
        }

        void HandleMovementAnimations()
        {
            anim.SetFloat("vertical", moveAmount, 0.4f, delta);
        }

        void HandleLockOnAnimations(Vector3 moveDir)
        {
           /* Vector3 relativeDir = transform.InverseTransformDirection(moveDir);
            float h = relativeDir.x;
            float v = relativeDir.z;

            anim.SetFloat("vertical", v, 0.2f, delta);
            anim.SetFloat("horizontal", h, 0.2f, delta);
            */
        }

       public void Jump()
       {
              onGround = OnGround();


              if (onGround)
              {
                  skipGroundCheck = true;
                  rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                  dJumpCounter = 0;
              }


              if (onGround == false && dJumpCounter < DoubleJumps)

              {
                  skipGroundCheck = true;
                  rigid.AddForce(Vector3.up * jumpHeight *1.2f, ForceMode.Impulse);
                  dJumpCounter++;
              }

            /* Vector3 targetVel = transform.forward * 7;
             targetVel.y = 5;
             rigid.velocity = targetVel;
             */
        }
      

        bool skipGroundCheck;
        public float skipTimer;
        bool prevGround;
        
         public bool OnGround()
        {
            if(skipGroundCheck)
            {
                skipTimer += delta;
                if(skipTimer > 0.2f)
                {
                    skipGroundCheck = false;
                }
                return false;
            }
            skipTimer = 0;
           

            bool r = false;

            Vector3 origin = transform.position + (Vector3.up * toGround);
            Vector3 dir = -Vector3.up;
            float dis = toGround + 0.3f;
            RaycastHit hit;
            Debug.DrawRay(origin, dir * dis);
            //r = true;
            if(Physics.Raycast(origin,dir, out hit, dis, ignoreLayers))
            {
                r = true;
                Vector3 targetPosition = hit.point;
                transform.position = targetPosition;
            }

            if(r && !prevGround)
            {
                anim.Play("Land");
            }




            prevGround = r;
            return r;
        }

        void GodMode()
        {
            if(god)
            {
                DoubleJumps = 10;
            }

            else
            {
                DoubleJumps = 1;
            }
        }

        public void TargetImg()
        {
            Vector3 fixedPos = new Vector3 (lockOnTarget.transform.position.x, lockOnTarget.transform.position.y+2, lockOnTarget.transform.position.z);
            targetImg.gameObject.transform.position = cam.WorldToScreenPoint(fixedPos);

            targetImg.gameObject.transform.Rotate(new Vector3(0, 0, -1));
        }

        public void FinishIdle()
        {

            anim.SetTrigger("idled");
        }

    }

}
