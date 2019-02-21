using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public bool isDead = false;

    float gunDmg = 1;
    float shotgunDmg = 0.5f;
    float specialAttackDmg = 3;
    bool godMode;
    public GameObject portalOn;

    [Header("Health")]
    public float enemyHP;

    [Header("Looking Player")]
    public Transform target;
    Transform enemy;
    Vector3 forwardDir;

    void Start () 
	{
		enemyHP = 10;
        enemy = this.transform;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyHP <= 0)
		{
			enemyDead();
		}
        
        if (Input.GetKeyDown(KeyCode.F10))
        {
            godMode = !godMode;
            //GodMode();
        }

       // float axisX = Input.GetAxis("Horizontal");
        //float axisY = Input.GetAxis("Vertical");

        forwardDir = target.position - enemy.position;
        forwardDir.y = 0;
        enemy.rotation = Quaternion.LookRotation(forwardDir, Vector3.up);

        /*  if(playerDistance < playerChase)
          {
              Chase();
          }
          */
    }
    

    public void enemyGunDamage()
    {
        enemyHP = enemyHP - gunDmg;
		Debug.Log("dmg");
        
    }

    public void enemyShotGunDamage()
    {
        enemyHP = enemyHP - shotgunDmg;
        Debug.Log("dmg");
       
    }

    public void enemySpecialDamage()
    {
        enemyHP = enemyHP - specialAttackDmg;
        Debug.Log("dmg");

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
