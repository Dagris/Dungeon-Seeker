using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpPlatform : MonoBehaviour
{
    public Animator upFx;
    public Camera gameCamera;
    public Camera cineCamera;

    void Start()
    {
        gameCamera.gameObject.SetActive(true);
        cineCamera.gameObject.SetActive(false);
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
        upFx.Play("Up");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
