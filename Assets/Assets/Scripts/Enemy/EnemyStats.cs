using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public Transform player;
    public float playerDistance;

    public float playerLook;

    public ParticleSystem bloodfx;
    //public float playerChase;

    public float rotationSmooth;

    public bool isDead = false;

    float gunDmg = 1;
    float shotgunDmg = 0.5f;
    float specialAttackDmg = 3;

    bool godMode;

    public GameObject portalOn;

    /* public float chaseStartRange;
     public float moveSpeed;
     */


    [Header("Health")]

    public float enemyHP;
	
	void Start () 
	{
		enemyHP = 10;
        
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyHP <= 0)
		{
			enemyDead();
		}

        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < playerLook)
        {
            lookAtPlayer();
        }


        if (Input.GetKeyDown(KeyCode.F10))
        {
            godMode = !godMode;
            //GodMode();
        }


        /*  if(playerDistance < playerChase)
          {
              Chase();
          }
          */
    }


    void lookAtPlayer()
    {
        Vector3 rotation = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        //transform.rotation = Quaternion.Slerp(transform.rotation, player, Time.deltaTime * rotationSmooth);
        transform.LookAt(rotation);

    }


    /* void Chase()
     {
         transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
         Debug.Log("stalker");
     }
     */



    public void enemyGunDamage()
    {
        enemyHP = enemyHP - gunDmg;
		Debug.Log("dmg");
        bloodfx.Play();
    }

    public void enemyShotGunDamage()
    {
        enemyHP = enemyHP - shotgunDmg;
        Debug.Log("dmg");
        bloodfx.Play();
    }

    public void enemySpecialDamage()
    {
        enemyHP = enemyHP - specialAttackDmg;
        Debug.Log("dmg");
        bloodfx.Play();
    }

    void enemyDead()
	{
        isDead = true;
		Destroy(gameObject);
        portalOn.gameObject.SetActive(true);
        
        Debug.Log("sa matao paco");
    }

   /* void GodMode ()
    {
        if (godMode == true)
        {
            gunDmg = 99999;
            shotgunDmg = 99999;
            specialAttackDmg = 99999;

        }

        if (godMode == false)
        {
            gunDmg = 1;
            shotgunDmg = 0.5f;
            specialAttackDmg = 3;
        }
    }
    */

    public void OnDestroy()
    {
        
       
    }

}
