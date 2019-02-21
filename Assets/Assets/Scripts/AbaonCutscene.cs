using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaonCutscene : MonoBehaviour
{
    public GameObject CamGame;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject AbaonBoss;
    public GameObject AbaonFake;
    public GameObject UI;
    public GameObject Tornadofx;
    public GameObject Audio;
   // public ParticleSystem trfx;


    // Start is called before the first frame update
    void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        //CamGame.SetActive(false);
        AbaonBoss.SetActive(false);
        AbaonFake.SetActive(false);
        UI.SetActive(false);
        Tornadofx.SetActive(false);
        Audio.SetActive(false);
        StartCoroutine("Cinematic");
    }

    // Update is called once per frame
    IEnumerator Cinematic ()
    {
        yield return new WaitForSeconds(2.2f);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(1);
        Tornadofx.SetActive(true);
        //trfx.Play();
        yield return new WaitForSeconds(1);
        AbaonFake.SetActive(true);
        Audio.SetActive(true);
        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        AbaonBoss.SetActive(true);
        AbaonFake.SetActive(false);
        CamGame.SetActive(true);
        Cam2.SetActive(false);
    }
}
