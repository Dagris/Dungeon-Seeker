using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class TargetUI : MonoBehaviour
    {
        Camera cam;
        EnemyGunTarget target; 
        Image image;
        public AudioSource lockfx;

        public GameObject gun;
        public GameObject plyr;

        // public float distanceToClosestEnemy;
        //EnemyGunTarget closest;
         public float distanceToEnemy;
        EnemyGunTarget[] allEnemies;


        public bool lockedOn;   

        int lockedEnemy;

        
        public static List<EnemyGunTarget> nearByEnemies = new List<EnemyGunTarget>();
        
        public ParticleSystem p1;


        private void Awake()
        {
            cam = Camera.main;
            image = gameObject.GetComponent<Image>();

            lockedOn = false;
            lockedEnemy = 0;
            Debug.Log("charged");
        }

        void Start()
        {
            
            //armL = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        }

        void Update()
        {
            //distanceToClosestEnemy = Mathf.Infinity;
            //closest = null;
            allEnemies = GameObject.FindObjectsOfType<EnemyGunTarget>();

             foreach (EnemyGunTarget currentEnemy in allEnemies)
            {
                distanceToEnemy = (currentEnemy.transform.position - plyr.transform.position).sqrMagnitude;
                /*if(distanceToEnemy < distanceToClosestEnemy)
                {
                distanceToClosestEnemy = distanceToEnemy;
                }*/
                
            }
            
            /*if(distanceToEnemy > 200)
            {
                lockedOn = false;
                image.enabled = false;
                lockedEnemy = 0;
                target = null;
            } */

            if (Input.GetButtonDown("R3") && !lockedOn /*&& distanceToEnemy < 200*/)
            {
                if (nearByEnemies.Count >= 1)
                {
                    lockedOn = true;
                    image.enabled = true;
                
                    lockedEnemy = 0;
                    target = nearByEnemies[lockedEnemy];
                    lockfx.Play();
                    Debug.Log("testing lock");
                }
            }

            else if ((Input.GetButtonDown("R3") && lockedOn) || nearByEnemies.Count == 0)
            {
                lockedOn = false;
                image.enabled = false;
                lockedEnemy = 0;
                target = null;
            }

            if(target == null)
            {
                lockedOn = false;
                image.enabled = false;
                lockedEnemy = 0;
            }

            //Switch Targets
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (lockedEnemy == nearByEnemies.Count - 1)
                {
                    //If End Of List Has Been Reached, Start Over
                    lockedEnemy = 0;
                    target = nearByEnemies[lockedEnemy];
                    lockfx.Play();
                }
                else
                {
                    //Move To Next Enemy In List
                    lockedEnemy++;
                    target = nearByEnemies[lockedEnemy];
                    lockfx.Play();
                }
            }

            if (lockedOn)
            {
                target = nearByEnemies[lockedEnemy];

                //Determine Crosshair Location Based On The Current Target
                gameObject.transform.position = cam.WorldToScreenPoint(target.transform.position);

                //Rotate Crosshair
                gameObject.transform.Rotate(new Vector3(0, 0, -1));

                gun.transform.LookAt(target.transform.position);
                
                p1.startColor = new Color(255, 0, 0);
            }

            else
            {
            // gun.transform.eulerAngles = new Vector3(0, 0, 0);

                //gun.transform.rotation = Quaternion.Euler(plyr.transform.rotation.x, plyr.transform.rotation.y, plyr.transform.rotation.z);

                p1.startColor = new Color(0, 132, 255);
            }

        }
    }


