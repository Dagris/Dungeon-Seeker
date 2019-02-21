using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour {

    //public int health;
    public int numOfLeaves;
    public Text leavesText;
    public Animator leaveAnim;
    //public AnimationClip dmg;

    GameObject playerHP;

    public Image[] leaves;
    public Sprite imgLeave;

    private void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player");
        numOfLeaves = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        leavesText.text = "X " + numOfLeaves.ToString();
        UpdateLife();
        /*
                if(numOfLeaves == 4 )
                {
                    // leaveAnim.Play("DMG");
                    leaveAnim.SetTrigger("Damaged");


                }

                if (numOfLeaves == 3)
                {
                    //leaveAnim.Play("DMG");

                    leaveAnim.SetTrigger("Damaged");
                }

                if (numOfLeaves == 2)
                {
                    //leaveAnim.Play("DMG");

                    leaveAnim.SetTrigger("Damaged");
                }



                if (numOfLeaves == 0)
                {
                    // leaveAnim.Play("DMG");

                    leaveAnim.SetTrigger("Damaged");

                }


                */

        if (numOfLeaves == 1)
        {
            leaveAnim.Play("LASTLIFE");
            GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }


    public void UpdateLife()
    {
        PlayerStats playerScript = playerHP.GetComponent<PlayerStats>();
        numOfLeaves = playerScript.HP;


    }


    /*	for (int i = 0; i < leaves.Length; i++)
        {
            if(i < numOfLeaves)
            {
                leaves[i].enabled = true;
            }

            else
            {
                leaves[i].enabled = false;
            }
        }

        
	}

   

    */
}
