using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpPlatformBoss : MonoBehaviour
{
    public Animator upFx;
    public Camera gameCamera;
    public Camera cineCamera;
    public Camera xq1;
    public Camera xq2;
    public GameObject xq;
    public GameObject inuki;
    public GameObject ui;
    public GameObject audio;
    public ParticleSystem spark;

    void Start()
    {
        gameCamera.gameObject.SetActive(true);
        cineCamera.gameObject.SetActive(false);
        xq1.gameObject.SetActive(false);
        xq2.gameObject.SetActive(false);
        xq.gameObject.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("GoingUp");
        }

    }

    IEnumerator GoingUp()
    {
        gameCamera.gameObject.SetActive(false);
        cineCamera.gameObject.SetActive(true);
        upFx.Play("Up2");
        yield return new WaitForSeconds(2);
        ui.gameObject.SetActive(false);
        audio.gameObject.SetActive(false);
        inuki.gameObject.SetActive(false);
        xq.gameObject.SetActive(true);
        xq1.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        xq2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        spark.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }
}
