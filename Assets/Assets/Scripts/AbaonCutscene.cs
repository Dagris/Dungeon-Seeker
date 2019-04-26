using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaonCutscene : MonoBehaviour
{
    public GameObject CamGame;
    public GameObject Cam2;
    public GameObject endCam;
    public GameObject xq1;
    public GameObject xq2;
    public GameObject xq;
    public GameObject AbaonBoss;
    public GameObject AbaonFake;
    public GameObject UI;
    public GameObject Audio;
   // public ParticleSystem trfx;


    // Start is called before the first frame update
    void Start()
    {
        Cam2.SetActive(true);
        endCam.SetActive(false);
        xq1.SetActive(false);
        xq2.SetActive(false);
        xq.gameObject.SetActive(false);
        //CamGame.SetActive(false);
        AbaonBoss.SetActive(false);
        AbaonFake.SetActive(false);
        UI.SetActive(false);
        Audio.SetActive(false);
        StartCoroutine("Cinematic");
    }

    // Update is called once per frame
    IEnumerator Cinematic ()
    {
        
        yield return new WaitForSeconds(2.5f);
        AbaonFake.SetActive(true);
        yield return new WaitForSeconds(3);
        Audio.SetActive(true);
        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        AbaonBoss.SetActive(true);
        AbaonFake.SetActive(false);
        CamGame.SetActive(true);
        Cam2.SetActive(false);
    }
}
